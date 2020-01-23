using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Api.Providers.DataBase
{
    public interface IDataBaseConnectionProvider
    {
        SqlConnection GetConnection();
    }
}
