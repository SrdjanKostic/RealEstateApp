namespace RealEstateApp.Authorization.Repositories;
public class AuthorizationRepository : IAuthorizationRepository
{
    public async Task<bool> CheckPermissionAsync(string userId, string permission)
    {
        return true;
    }
}
