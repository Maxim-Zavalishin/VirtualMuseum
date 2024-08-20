using Microsoft.AspNetCore.Mvc;

namespace VirtualMuseum.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TopicController : Controller
{
    [HttpGet]
    public IActionResult GetTopic()
    {
        return Ok();
    }
    [HttpGet("{id}")]
    public IActionResult GetTopicById(int id)
    {
        return Ok();
    }
    [HttpPost]
    public IActionResult CreateTopic(int id)
    {
        return Ok();
    }
    [HttpDelete]
    public IActionResult DeleteTopic(int id)
    {
        return Ok();
    }
    [HttpPut]
    public IActionResult UpdateTopic(int id)
    {
        return Ok();
    }
}