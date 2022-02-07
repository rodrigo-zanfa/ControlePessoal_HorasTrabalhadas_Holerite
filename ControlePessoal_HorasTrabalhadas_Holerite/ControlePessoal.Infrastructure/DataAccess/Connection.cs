using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePessoal.Infrastructure.DataAccess
{
    public class Connection
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection($"Data source={Environment.GetEnvironmentVariable("DB_DATA_SOURCE")};" +
                $"Initial Catalog={Environment.GetEnvironmentVariable("DB_INITIAL_CATALOG")};" +
                $"User Id={Environment.GetEnvironmentVariable("DB_USER_ID")};" +
                $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};" +
                $"Connect Timeout=30;Trusted_Connection=False;");
        }
    }
}
