using Microsoft.AspNetCore.Http.HttpResults;
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
    
    /// <summary>
    /// Получение списка всех статей без текста.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Получение конкретной статьи по Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CollectionResult<ArticleDto>>> GetArticleById(int id)
    {
        var response = await _articleService.GetArticleByIdAsync(id);

        if (response.IsSuccess)
        {
            return Ok(response);
        }
        
        return BadRequest(response);
    }

    [HttpPost]
    public async Task<ActionResult<BaseResult<bool>>> CreateArticle([FromBody]CreateArticleDto dto)
    {
        var response = await _articleService.CreateArticleAsync(dto);

        if (response.IsSuccess)
        {
            return Ok(response.Data);
        }

        return BadRequest(response.Data);
    }
}