using DinnerApp.Application.Authentication.Commands.Register;
using DinnerApp.Application.Authentication.Queries.Login;
using DinnerApp.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerApp.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController(IMediator mediator) : ApiController
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;
    
    [Route("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.UserName, request.Email, request.UserName, request.Password);

        var authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthResults(authResult)),
            errors => Problem(errors));
    }

    

    [Route("Login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await _mediator.Send(query);


        return authResult.Match(
            authResult => Ok(MapAuthResults(authResult)),
            errors => Problem(errors));
    }

}