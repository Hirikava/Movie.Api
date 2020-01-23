using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.ClientModels.Authorization
{
    public class RegistrationRequest
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
