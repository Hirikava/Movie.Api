using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.ClientModels.Authorization.LogIn
{
    public class LogInResponse
    {
        public string Sid { get; set; }
        public LogInStatus Status { get; set; }
    }
}
