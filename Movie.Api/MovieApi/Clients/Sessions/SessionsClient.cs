using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Movie.Api.Providers.DataBase;

namespace Movie.Api.Clients.Sessions
{
    public class SessionsClient : ISessionsClient
    {
        private readonly IDataBaseConnectionProvider dataBaseConnectionProvider;

        public SessionsClient(IDataBaseConnectionProvider dataBaseConnectionProvider)
        {
            this.dataBaseConnectionProvider = dataBaseConnectionProvider;
        }

        public async Task<Guid> CreateSessionOnUser(Guid userId)
        {
            using (var connection = dataBaseConnectionProvider.GetConnection())
            {
                connection.Open();
                var newSessionId = Guid.NewGuid();
                var command = new SqlCommand($"INSERT INTO USessions VALUES('{newSessionId.ToString()}','{userId.ToString()}')",connection);
                await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                return newSessionId;
            }
        }
    }
}