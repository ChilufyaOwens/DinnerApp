using DinnerApp.Application.Authentication.Commands.Register;
using DinnerApp.Application.Authentication.Queries.Login;
using DinnerApp.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerApp.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController( IMediator mediator, IMapper mapper) : ApiController
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;
    
    [Route("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        
        var authResult = await _mediator.Send(command);

        return authResult.Match(
            result => Ok(_mapper.Map<AuthenticationResponse>(result)),
            Problem);        
    }

    

    [Route("Login")]
     public async Task<IActionResult> Login(LoginRequest request)
     {
         var query = _mapper.Map<LoginQuery>(request);
          var authResult = await _mediator.Send(query);
   
        return authResult.Match(
            result => Ok(_mapper.Map<AuthenticationResponse>(result)),
            Problem);
     }
     
}