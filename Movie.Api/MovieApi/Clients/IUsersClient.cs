﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Api.Clients
{
    public interface IUsersClient
    {
        bool IsUserNameExists(string userName);
        Task<Guid> RegisterNewUserAsync(string userName);
    }
}
