using Microsoft.AspNetCore.Mvc;

namespace DinnerApp.Api.Controllers;

[Route("api/[controller]")]
public class DinnersController : ApiController 
{
    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
    
}