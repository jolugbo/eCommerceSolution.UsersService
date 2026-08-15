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
        _configuration = configuration;
        string? connectionString = _configuration.GetConnectionString("PostgresConnection");
        _connection = new NpgsqlConnection(connectionString);
    }
    public IDbConnection DbConnection => _connection;
}
