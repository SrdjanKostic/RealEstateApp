using MediatR;

namespace RealEstateApp.Authorization.Commands;
public class AuthorizeCommand : IRequest<bool>
{
    public string UserId { get; set; }
    public string Permission { get; set; }
}
