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
        [Route("")]
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
        };
        }
    }
}