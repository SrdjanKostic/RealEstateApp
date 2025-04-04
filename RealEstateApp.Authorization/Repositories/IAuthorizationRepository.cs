namespace RealEstateApp.Authorization.Repositories;
public interface IAuthorizationRepository
{
    Task<bool> CheckPermissionAsync(string userId, string permission);
}