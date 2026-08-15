using AutoMapper;
using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.Entities.RepositoryContracts;
using eCommerce.Infrastructure.DBContext;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository : IUserRepository
{
    private DapperDbContext _dbContext;
    public UsersRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();
        string query = "INSERT INTO public.\"Users\"(\"UserId\", \"Email\", \"Password\", \"PersonName\", \"Gender\") VALUES (@UserId, @Email, @Password,@PersonName,@Gender)";
        int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);
        if (rowCountAffected > 0)
        {
            return user;
        }
        else return null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = "SELECT  * FROM public.\"Users\" where";
        return new ApplicationUser()
        {
            UserId = Guid.NewGuid(),
            Email = email,
            PersonName = "John Doe",
            Gender = "Male",
            Password = password
        };
    }
}
