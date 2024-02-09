namespace DinnerApp.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Login(string userName, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(), 
            "Chilufya", 
            "Owens", 
            "chilufyao@ownat.com", 
            userName, 
            "token");
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string userName, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(), firstName, lastName, email, userName, "token");
    }
}