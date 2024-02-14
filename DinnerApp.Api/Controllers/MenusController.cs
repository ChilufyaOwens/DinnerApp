using DinnerApp.Application.Menus.Commands.CreateMenu;
using DinnerApp.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerApp.Api.Controllers;

[Route("hosts/{hostId}/[controller]")]
public class MenusController(IMapper mapper, ISender mediator) : ApiController
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;

    [HttpPost] 
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));
 
        var createMenuResult = await _mediator.Send(command);

        return createMenuResult.Match(
             success => Ok(_mapper.Map<CreateMenuResponse>(success)),
            Problem);

    }
}  