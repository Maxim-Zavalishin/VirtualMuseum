using System.Net.WebSockets;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualMuseum.Application.Resources;
using VirtualMuseum.Domain.Dto.Article;
using VirtualMuseum.Domain.Dto.Author;
using VirtualMuseum.Domain.Entity;
using VirtualMuseum.Domain.Enum;
using VirtualMuseum.Domain.Interfaces;
using VirtualMuseum.Domain.Interfaces.Services;
using VirtualMuseum.Domain.Result;

namespace VirtualMuseum.Application.Services;

public class ArticleServices : IArticleService
{
    private readonly IBaseRepository<Article> _articleRepository;
    private readonly IBaseRepository<AuthorArticle> _authorArticleRepository;
    private readonly IBaseRepository<Author> _authorRepository;
    private readonly IMapper _mapper;

    public ArticleServices(IBaseRepository<Article> articleRepository, IBaseRepository<AuthorArticle> authorArticleRepository, IMapper mapper, IBaseRepository<Author> authorRepository)
    {
        _articleRepository = articleRepository;
        _authorArticleRepository = authorArticleRepository;
        _mapper = mapper;
        _authorRepository = authorRepository;
    }

    public Task<CollectionResult<ArticleDto>> GetArticlesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<CollectionResult<GetArticleDto>> GetIdArticlesAsync()
    {
        try
        {
            
            // var articlesWithAuthors = await _articleRepository
            //     .GetAll()
            //     .Select(article => new GetArticleDto(
            //         article.Name,
            //         article.Keywords,
            //         article.AuthorArticles.Select(authorArticle => $"{authorArticle.Author.Firstname} {authorArticle.Author.Lastname}").ToList()
            //     ))
            //     .ToListAsync();
            
            var articlesWithAuthors = await _articleRepository
                .GetAll()
                .Select(article => new GetArticleDto(
                    article.Name,
                    article.Keywords,
                    article.AuthorArticles
                        .Where(authorArticle => authorArticle.Author != null)
                        .Select(authorArticle => $"{authorArticle.Author.Firstname} {authorArticle.Author.Lastname}")
                        .ToList()
                ))
                .ToListAsync();
            
            return new CollectionResult<GetArticleDto>()
            {
                Data = articlesWithAuthors
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<BaseResult<ArticleDto>> GetIArticleByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResult<ArticleDto>> CreateArticleAsync(CreateArticleDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResult<ArticleDto>> DeleteArticleAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResult<ArticleDto>> UpdateArticleAsync(ArticleDto dto)
    {
        throw new NotImplementedException();
    }
}