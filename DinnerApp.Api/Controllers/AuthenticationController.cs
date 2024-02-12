using DinnerApp.Application.Authentication.Commands.Register;
using DinnerApp.Application.Authentication.Queries.Login;
using DinnerApp.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerApp.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController(ISender mediator, IMapper mapper) : ApiController
{
    private readonly ISender _mediator = mediator;
    private readonly IMapper _mapper = mapper;
    
    [Route("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    { 
        var command = _mapper.Map<RegisterCommand>(request);
       
        var authResult = await _mediator.Send(command);
        return authResult.Match(
            authResponse => Ok(_mapper.Map<AuthenticationResponse>(authResponse)),
            Problem);
    }

   
    [Route("Login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        //var query = new LoginQuery(request.Email, request.Password);
        var authResult = await _mediator.Send(query);

        return authResult.Match(
            authResponse => Ok(_mapper.Map<AuthenticationResponse>(authResponse)),
            Problem);
    }

}