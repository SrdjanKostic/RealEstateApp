using RealEstateApp.Authentication.Entities;

namespace RealEstateApp.Authentication.Repositories;
public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<bool> AddUserAsync(User user);
}
