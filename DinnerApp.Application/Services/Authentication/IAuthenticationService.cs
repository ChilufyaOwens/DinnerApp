namespace DinnerApp.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Login(string userName, string password);
    AuthenticationResult Register(string firstName, string lastName, string email, string userName, string password);
}