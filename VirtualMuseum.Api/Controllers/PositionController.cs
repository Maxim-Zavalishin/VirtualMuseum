using Microsoft.AspNetCore.Mvc;
using VirtualMuseum.Application.Services;
using VirtualMuseum.Domain.Dto.Position;
using VirtualMuseum.Domain.Interfaces.Services;

namespace VirtualMuseum.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionController : Controller
{
    private readonly IPositionService _positionService;

    public PositionController(IPositionService positionService)
    {
        _positionService = positionService;
    }


    [HttpGet]
    public IActionResult GetPosition()
    {
        var response = _positionService.GetPositionsAsync();

        if (response.IsSuccess)
        {
            return Ok(response);
        }
        
        return BadRequest(response);
    }
    [HttpGet("{id}")]
    public IActionResult GetPositionById(int id)
    {
        return Ok();
    }
    [HttpPost]
    public async Task<IActionResult> CreatePosition(PositionDto dto)
    {
        var response = await _positionService.CreatePositionAsync(dto);

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    [HttpDelete]
    public IActionResult DeletePosition(int id)
    {
        return Ok();
    }
    [HttpPut]
    public IActionResult UpdatePosition(int id)
    {
        return Ok();
    }
}