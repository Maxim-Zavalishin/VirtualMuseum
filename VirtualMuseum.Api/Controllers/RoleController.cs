using Microsoft.AspNetCore.Mvc;

namespace VirtualMuseum.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : Controller
{
    [HttpGet]
    public IActionResult GetRole()
    {
        return Ok();
    }
    [HttpGet("{id}")]
    public IActionResult GetRoleById(int id)
    {
        return Ok();
    }
    [HttpPost]
    public IActionResult CreateRole(int id)
    {
        return Ok();
    }
    [HttpDelete]
    public IActionResult DeleteRole(int id)
    {
        return Ok();
    }
    [HttpPut]
    public IActionResult UpdateRole(int id)
    {
        return Ok();
    }
}