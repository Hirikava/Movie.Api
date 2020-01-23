using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Api.Clients.Sessions
{
    public interface ISessionsClient
    {
        Task<Guid> CreateSessionOnUser(Guid userId);
    }
}
