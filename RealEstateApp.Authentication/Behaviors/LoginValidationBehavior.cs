using MediatR;
using Microsoft.AspNetCore.Http;
using RealEstateApp.Authentication.Common;
public class LoginValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginValidationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is IRequireNoAuthentication)
        {
            return await next();
        }

        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext == null || httpContext.User.Identity == null || !httpContext.User.Identity.IsAuthenticated)
        {
            throw new UnauthorizedAccessException("Korisnik nije ulogovan.");
        }

        return await next();
    }
}
