using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace WebPlatAssignment_DF.Data
{
    public class ApplicationDbContext
    {
       private readonly IConfiguration configuration;
        private readonly string connectionString;
        public ApplicationDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("defaultConnection");
        }
        public IDbConnection CreateConnection()=>new SqlConnection(connectionString);
    }
}
