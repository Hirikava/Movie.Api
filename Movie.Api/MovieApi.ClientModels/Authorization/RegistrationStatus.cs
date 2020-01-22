using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.ClientModels.Authorization
{
    public enum RegistrationStatus
    {
        Registred,
        UserAlreadyExists,
        IncorrectUserName,
    }
}
