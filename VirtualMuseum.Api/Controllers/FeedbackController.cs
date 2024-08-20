using Microsoft.AspNetCore.Mvc;

namespace VirtualMuseum.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    [HttpGet]
    public IActionResult GetFeedback()
    {
        return Ok();
    }
    [HttpGet("{id}")]
    public IActionResult GetFeedbackById(int id)
    {
        return Ok();
    }
    [HttpPost]
    public IActionResult CreateFeedback(int id)
    {
        return Ok();
    }
    [HttpDelete]
    public IActionResult DeleteFeedback(int id)
    {
        return Ok();
    }
    [HttpPut]
    public IActionResult UpdateFeedback(int id)
    {
        return Ok();
    }
}