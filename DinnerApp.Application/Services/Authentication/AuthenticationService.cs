using DinnerApp.Application.Common.Interfaces.Authentication;
using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Domain.Common.Errors;
using DinnerApp.Domain.Entities;
using ErrorOr;

namespace DinnerApp.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository) : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    public ErrorOr<AuthenticationResult> Login(
        string email,
        string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredential;
        }

        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredential;
        }

        var token = _tokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user, 
            token);
    }

    public ErrorOr<AuthenticationResult> Register(
        string firstName, 
        string lastName, 
        string email, 
        string userName, 
        string password)
    {
        // Validate user doesn't exist 
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            UserName = userName,
            Password = password
        };
        
        _userRepository.Add(user);
       
        var token = _tokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user, token);
    }
}