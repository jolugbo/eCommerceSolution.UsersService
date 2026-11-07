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
        string? connectionStringTemplate = _configuration.GetConnectionString("PostgresConnection")!;
        string connectionString = Environment.ExpandEnvironmentVariables(connectionStringTemplate).Replace("$POSTGRES_HOST", _configuration["POSTGRES_HOST"])
            .Replace("$POSTGRES_DATABASE", _configuration["POSTGRES_DATABASE"])
            .Replace("$POSTGRES_USER", _configuration["POSTGRES_USER"])
            .Replace("$POSTGRES_PASSWORD", _configuration["POSTGRES_PASSWORD"])
            .Replace("$POSTGRES_PORT", _configuration["POSTGRES_PORT"]);
        _connection = new NpgsqlConnection(connectionString);
    }
    public IDbConnection DbConnection => _connection;
}
