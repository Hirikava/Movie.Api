using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using Movie.Api.Clients;
using MovieApi.ClientModels.Authorization;

namespace Movie.Api.Controllers
{
    [RoutePrefix("v1/auth")]
    public class AuthorizationController : ApiController
    {

        private readonly IUsersClient usersClient;

        public AuthorizationController(IUsersClient usersClient)
        {
            this.usersClient = usersClient;
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

            return new RegistrationResponse()
            {
                Status = RegistrationStatus.Registred,
                Sid = newUserId.ToString()
        };
        }
    }
}