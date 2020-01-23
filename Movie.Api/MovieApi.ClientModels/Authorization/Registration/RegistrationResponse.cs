using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.ClientModels.Authorization
{
    public class RegistrationResponse
    {
        public RegistrationStatus Status { get; set; }
        public string Sid { get; set; } 
        public string UserName { get; set; }
    }
}
