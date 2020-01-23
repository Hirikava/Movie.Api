using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using Movie.Api.Clients;
using Movie.Api.Clients.Sessions;
using MovieApi.ClientModels.Authorization;
using MovieApi.ClientModels.Authorization.LogIn;

namespace Movie.Api.Controllers
{
    [RoutePrefix("v1/auth")]
    public class AuthorizationController : ApiController
    {

        private readonly IUsersClient usersClient;
        private readonly ISessionsClient sessionsClient;

        public AuthorizationController(IUsersClient usersClient, ISessionsClient sessionsClient)
        {
            this.usersClient = usersClient;
            this.sessionsClient = sessionsClient;
        }

        [HttpPost]
        [Route("registration")]
        public async Task<RegistrationResponse> RegisterNewUser([FromBody] RegistrationRequest registrationRequest)
        {
            if (await usersClient.IsUserNameExists(registrationRequest.UserName).ConfigureAwait(false))
                return new RegistrationResponse()
                {
                    Status = RegistrationStatus.UserAlreadyExists,
                };

            var newUserId = await usersClient.RegisterNewUserAsync(registrationRequest.UserName,registrationRequest.PasswordHash).ConfigureAwait(false);
            var newSessionId = await sessionsClient.CreateSessionOnUser(newUserId).ConfigureAwait(false);

            return new RegistrationResponse()
            {
                Status = RegistrationStatus.Registred,
                Sid = newSessionId.ToString(),
                UserName = registrationRequest.UserName
            };
        }

        [HttpPost]
        [Route("log-in")]
        public async Task<LogInResponse> LogIn([FromBody] LogInRequest logInRequest)
        {
            var uId = await usersClient.GetUserIdByCredetinals(logInRequest.UserName,logInRequest.PasswordHash).ConfigureAwait(false);
            if (!uId.HasValue)
                return new LogInResponse()
                {
                    Status = LogInStatus.UserNameOrPasswprdIncorrect,
                };

            var newSid = await sessionsClient.CreateSessionOnUser(uId.Value).ConfigureAwait(false);
            return new LogInResponse()
            {
                Status = LogInStatus.LogedIn,
                Sid = newSid.ToString()
            };
        }
    }
}