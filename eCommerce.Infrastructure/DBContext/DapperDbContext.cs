using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
namespace eCommerce.Infrastructure.DBContext;

public  class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;
    public DapperDbContext(IConfiguration configuration)
    {
        // Initialize your Dapper database context here
        string connectionStringTemplate = configuration.GetConnectionString("PostgresConnection")!;
        string connectionString = connectionStringTemplate.Replace("$POSTGRES_HOST",
            Environment.GetEnvironmentVariable("POSTGRES_HOST")).
            Replace("$POSTGRES_PASSWORD",
            Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"));

        _configuration = configuration;
        _connection = new NpgsqlConnection(connectionString);
    }
    public IDbConnection DbConnection => _connection;
}
