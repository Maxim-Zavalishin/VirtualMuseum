using Microsoft.AspNetCore.Mvc;

namespace VirtualMuseum.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    [HttpGet]
    public IActionResult GetUser()
    {
        return Ok(1);
    }
    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        return Ok(1);
    }
    [HttpDelete]
    public IActionResult DeleteUser(int id)
    {
        return Ok(1);
    }
    [HttpPut]
    public IActionResult UpdateUser(int id)
    {
        return Ok(1);
    }
}