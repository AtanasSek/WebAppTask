using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace WebAppTask.Context
{
    public class DapperContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("dapperschema");
        }

        public IDbConnection CreateConnection() => new MySqlConnection(connectionString); 
    }
}
