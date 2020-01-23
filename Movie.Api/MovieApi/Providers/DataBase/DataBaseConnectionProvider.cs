using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Movie.Api.Providers.DataBase
{
    public class DataBaseConnectionProvider : IDataBaseConnectionProvider
    {
        private readonly string connString;
        public DataBaseConnectionProvider(string dataSource, string dataBase, string userName, string password)
        {
            connString = @"Data Source=" + dataSource + ";Initial Catalog="
                                + dataBase + ";Persist Security Info=True;User ID=" + userName + ";Password=" + password;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connString);
        }
    }
}