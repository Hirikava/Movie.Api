using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Movie.Api.Providers.DataBase;

namespace Movie.Api.Clients
{
    public class UsersClient : IUsersClient
    {

        private readonly IDataBaseConnectionProvider dataBaseConnectionProvider;

        public UsersClient(IDataBaseConnectionProvider dataBaseConnectionProvider)
        {
            this.dataBaseConnectionProvider = dataBaseConnectionProvider;
        }

        public async Task<bool> IsUserNameExists(string userName)
        {

            using (var connection = dataBaseConnectionProvider.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM Users WHERE userName = '{userName}'",connection);
                var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
                var result = reader.HasRows;
                reader.Close();
                return result;
            }
        }

        public async Task<Guid> RegisterNewUserAsync(string userName, string passwordHash)
        {
            using (var connection = dataBaseConnectionProvider.GetConnection())
            {
                connection.Open();
                var newUserId = Guid.NewGuid();
                var command = new SqlCommand($"INSERT INTO Users VALUES ('{newUserId.ToString()}','{userName}','{passwordHash}')",connection);
                var rowsAffected = await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                return newUserId;
            }
        }
    }
}