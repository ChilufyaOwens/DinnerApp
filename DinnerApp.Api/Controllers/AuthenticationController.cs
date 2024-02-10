using DinnerApp.Application.Services.Authentication;
using DinnerApp.Contracts.Authentication;
using DinnerApp.Domain.Common.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace DinnerApp.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ApiController
{
    private readonly IAuthenticationService _authenticationService = authenticationService;

    [Route("register")]
     public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(
             request.FirstName,
             request.LastName,
             request.Email,
             request.UserName,
             request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthResults(authResult)),
            errors => Problem(errors));        
    }

    private static AuthenticationResponse MapAuthResults(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
                  authResult.User.Id,
                  authResult.User.FirstName,
                  authResult.User.LastName,
                  authResult.User.Email,
                  authResult.User.UserName,
                  authResult.Token);
    }

    [Route("Login")]
     public IActionResult Login(LoginRequest request)
     {
          var authResult = _authenticationService   .Login(
              request. Email, 
              request.Password);
        

        return authResult.Match(
            authResult => Ok(MapAuthResults(authResult)),
            errors => Problem(errors));
     }
     
}