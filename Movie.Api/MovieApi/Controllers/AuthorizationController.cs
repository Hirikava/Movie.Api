using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using MovieApi.ClientModels.Authorization;

namespace Movie.Api.Controllers
{
    [RoutePrefix("v1/auth")]
    public class AuthorizationController : ApiController
    {

        [HttpPost]
        [Route("")]
        public async Task<RegistrationResponse> RegisterNewUser([FromBody] RegistrationRequest registrationRequest)
        {
            return new RegistrationResponse()
            {
                Status = RegistrationStatus.Registred,
                Sid = registrationRequest.UserName + registrationRequest.PasswordHash
            };
        }
    }
}