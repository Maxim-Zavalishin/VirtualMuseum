using Microsoft.AspNetCore.Mvc;

namespace VirtualMuseum.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubTopicController : Controller
{
    [HttpGet]
    public IActionResult GetSubTopic()
    {
        return Ok();
    }
    [HttpGet("{id}")]
    public IActionResult GetSubTopicById(int id)
    {
        return Ok();
    }
    [HttpPost]
    public IActionResult CreateSubTopic(int id)
    {
        return Ok();
    }
    [HttpDelete]
    public IActionResult DeleteSubTopic(int id)
    {
        return Ok();
    }
    [HttpPut]
    public IActionResult UpdateSubTopic(int id)
    {
        return Ok();
    }
}