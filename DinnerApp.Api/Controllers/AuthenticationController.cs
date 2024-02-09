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
          authResult.Id,
          authResult.FirstName,
          authResult.LastName,
          authResult.Email,
          authResult.UserName,
          authResult.Token);

          return Ok(response);
     }

     [Route("Login")]
     public IActionResult Login(LoginRequest request)
     {
          var authResult = authenticationService.Login(request.Username, request.Password);

          var response = new AuthenticationResponse(
               authResult.Id,
               authResult.FirstName,
               authResult.LastName,
               authResult.Email,
               authResult.UserName,
               authResult.Token
          );
          return Ok(response);
     }
     
}