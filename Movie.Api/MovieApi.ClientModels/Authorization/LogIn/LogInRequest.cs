using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.ClientModels.Authorization.LogIn
{
    public class LogInRequest
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
