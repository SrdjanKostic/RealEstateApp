using Dapper;
using System.Data;
using RealEstateApp.Authentication.Entities;

namespace RealEstateApp.Authentication.Repositories;
public class UserRepository : IUserRepository
{
    private readonly IDbConnection _db;

    public UserRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _db.QueryFirstOrDefaultAsync<User>(
            "SELECT * FROM Users WHERE Email = @Email", new { Email = email });
    }

    public async Task<bool> AddUserAsync(User user)
    {
        var query = "INSERT INTO Users (Email, PasswordHash) VALUES (@Email, @PasswordHash)";
        var result = await _db.ExecuteAsync(query, new { user.Email, user.PasswordHash });
        return result > 0;
    }
}
