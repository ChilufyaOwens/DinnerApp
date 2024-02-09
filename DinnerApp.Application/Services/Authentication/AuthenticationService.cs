using DinnerApp.Application.Common.Interfaces.Authentication;

namespace DinnerApp.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator tokenGenerator) : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;

    public AuthenticationResult Login(
        string userName, 
        string password)
    {
        var userId = Guid.NewGuid();

        var token = _tokenGenerator.GenerateToken(userId, "Chilufya", "Owens");
        return new AuthenticationResult(
            userId, 
            "Chilufya", 
            "Owens", 
            "chilufyao@ownat.com", 
            userName, 
            token);
    }

    public AuthenticationResult Register(
        string firstName, 
        string lastName, 
        string email, 
        string userName, 
        string password)
    {
        var userId = Guid.NewGuid();
        var token = _tokenGenerator.GenerateToken(userId, firstName, lastName);
        
        return new AuthenticationResult(
            userId, firstName, lastName, email, userName, token);
    }
}