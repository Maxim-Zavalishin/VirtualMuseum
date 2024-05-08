using Microsoft.AspNetCore.Mvc;
using VirtualMuseum.Domain.Dto.Article;
using VirtualMuseum.Domain.Interfaces.Services;
using VirtualMuseum.Domain.Result;

namespace VirtualMuseum.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController : ControllerBase
{
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<CollectionResult<GetArticleDto>>> GetArticle()
    {
        var response = await _articleService.GetIdArticlesAsync();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    public async Task<ActionResult<CollectionResult<ArticleDto>>> GetArticleById(int id)
    {
        var response = await _articleService.GetArticleByIdAsync(id);

        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }
}