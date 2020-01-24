using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Movie.Api.Providers.DataBase;

namespace Movie.Api.Providers.Authorization
{
    public class SessionAuthorizationProvider : IAuthorizationProvider
    {
        private readonly IDataBaseConnectionProvider dataBaseConnectionProvider;
        private readonly string sessionId;

        public SessionAuthorizationProvider(IDataBaseConnectionProvider dataBaseConnectionProvider,string sessionId)
        {
            this.dataBaseConnectionProvider = dataBaseConnectionProvider;
            this.sessionId = sessionId;
        }

        public async Task<string> GetUserId()
        {
            using (var connection = dataBaseConnectionProvider.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM USessions WHERE SessionId = '{sessionId}'", connection);
                var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

                if (reader.Read())
                {
                    return reader.GetString(1);
                }
            }

            return null;
        }
    }
}