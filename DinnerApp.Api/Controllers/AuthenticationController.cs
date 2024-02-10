using DinnerApp.Application.Services.Authentication;
using DinnerApp.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DinnerApp.Api.Controllers;
[ApiController]
[Route("api/auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
     [Route("register")]
     public IActionResult Register(RegisterRequest request)
     {
          var authResult = authenticationService.Register(
               request.FirstName,
               request.LastName,
               request.Email,
               request.UserName,
               request.Password);
          
          var response = new AuthenticationResponse(
          authResult.User.Id,
          authResult.User.FirstName,
          authResult.User.LastName,
          authResult.User.Email,
          authResult.User.UserName,
          authResult.Token);

          return Ok(response);
     }

     [Route("Login")]
     public IActionResult Login(LoginRequest request)
     {
          var authResult = authenticationService.Login(request. Email, request.Password);

          var response = new AuthenticationResponse(
               authResult.User.Id,
               authResult.User.FirstName,
               authResult.User.LastName,
               authResult.User.Email,
               authResult.User.UserName,
               authResult.Token
          );
          return Ok(response);
     }
     
}