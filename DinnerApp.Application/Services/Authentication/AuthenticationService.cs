using DinnerApp.Application.Common.Interfaces.Authentication;
using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Domain.Entities;

namespace DinnerApp.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository) : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    public AuthenticationResult Login(
        string email,
        string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception($"User with given email: {email} does not exists");
        }

        if (user.Password != password)
        {
            throw new Exception("Invalid Password!");
        }

        var token = _tokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
        return new AuthenticationResult(
            user, 
            token);
    }

    public AuthenticationResult Register(
        string firstName, 
        string lastName, 
        string email, 
        string userName, 
        string password)
    {
        // Validate user doesn't exist 
        if (_userRepository.GetUserByEmail(email) is not null)
        {
             throw new Exception($"User with given email: {email} already exist");
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
       
        var token = _tokenGenerator.GenerateToken(user.Id, firstName, lastName);
        
        return new AuthenticationResult(
            user, token);
    }
}