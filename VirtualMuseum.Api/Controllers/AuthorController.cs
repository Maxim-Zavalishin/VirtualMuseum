using Microsoft.AspNetCore.Mvc;
using VirtualMuseum.Domain.Dto.Author;
using VirtualMuseum.Domain.Interfaces.Services;
using VirtualMuseum.Domain.Result;

namespace VirtualMuseum.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public IActionResult GetAuthor()
    {
        return Ok();
    }
    [HttpGet("{id}")]
    public IActionResult GetAuthorById(int id)
    {
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<CollectionResult<GetAuthorDto>>> GetAuthors()
    {
        var response = await _authorService.GetAuthorsArticleAsync();

        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<BaseResult>> CreateAuthor(CreateAuthorDto dto)
    {
        var response = await _authorService.CreateAutorAsync(dto);

        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }
    
    [HttpDelete]
    public IActionResult DeleteAuthor(int id)
    {
        return Ok();
    }
    [HttpPut]
    public IActionResult UpdateAuthor(int id)
    {
        return Ok();
    }
}