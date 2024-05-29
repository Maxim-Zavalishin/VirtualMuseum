using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualMuseum.Application.Resources;
using VirtualMuseum.Domain.Dto.Article;
using VirtualMuseum.Domain.Dto.Author;
using VirtualMuseum.Domain.Dto.Feedbacks;
using VirtualMuseum.Domain.Dto.User;
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
    private readonly IBaseRepository<SubTopic> _subTopic;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ArticleServices(IBaseRepository<Article> articleRepository, IBaseRepository<AuthorArticle> authorArticleRepository, IMapper mapper, IBaseRepository<Author> authorRepository, IUnitOfWork unitOfWork, IBaseRepository<SubTopic> subTopic)
    {
        _articleRepository = articleRepository;
        _authorArticleRepository = authorArticleRepository;
        _mapper = mapper;
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _subTopic = subTopic;
    }
    
    public async Task<CollectionResult<GetArticleDto>> GetIdArticlesAsync()
    {
        try
        {
            var articles = await _articleRepository
                .GetAll()
                .Select(article => new GetArticleDto(
                    article.Id,
                    article.Name,
                    article.Keywords,
                    article.AuthorArticles
                        .Where(authorArticle => authorArticle.Author != null)
                        .Select(authorArticle => new AuthorNameDto(
                            authorArticle.Author.Id,
                            authorArticle.Author.Firstname,
                            authorArticle.Author.Lastname
                            ))
                        .ToList()
                ))
                .ToListAsync();

            if (articles == null)
            {
                return new CollectionResult<GetArticleDto>()
                {
                    ErrorMassage = ErrorMessage.ArticleNotFount,
                    ErrorCode = (int)ErrorCode.ArticleNotFount
                };
            }

            return new CollectionResult<GetArticleDto>()
            {
                Data = articles
            };
        }
        catch (Exception e)
        {
            return new CollectionResult<GetArticleDto>()
            {
                ErrorCode = (int)ErrorCode.InternalServerError,
                ErrorMassage = ErrorMessage.InternalServerError
            };
        }
    }

    public async Task<BaseResult<ArticleDto>> GetArticleByIdAsync(int id)
    {
        try
        {
            var articleDto = await _articleRepository.GetAll()
                .Where(article => article.Id == id)
                .Select(article => new ArticleDto(
                    article.Id,
                    article.Name,
                    article.Text,
                    article.Keywords,
                    article.SubTopic.Name,
                    article.AuthorArticles
                        .Where(authorArticle => authorArticle.Author != null)
                        .Select(authorArticle => new AuthorNameDto(
                            authorArticle.Author.Id,
                            authorArticle.Author.Firstname,
                            authorArticle.Author.Lastname
                        )).ToList(),
                    article.Feedbacks
                        .Where(feedback => feedback != null)
                        .Where(feedback => feedback.User != null)
                        .Select(feedback => new FeedbackDto(
                            feedback.Text,
                            feedback.CreatedAt,
                            new UserFeedbackDto(
                                feedback.User.Firstname,
                                feedback.User.Lastname,
                                feedback.User.Login
                            )
                        )).ToList()
                ))
                .FirstOrDefaultAsync();

            return new BaseResult<ArticleDto>()
            {
                Data = articleDto
            };

        }
        catch (Exception e)
        {
            return new BaseResult<ArticleDto>()
            {
                ErrorCode = (int)ErrorCode.InternalServerError,
                ErrorMassage = ErrorMessage.InternalServerError
            };
        }
    }

    public async Task<BaseResult<bool>> CreateArticleAsync(CreateArticleDto dto)
    {
        try
        {
            var article = await _articleRepository.GetAll()
                .FirstOrDefaultAsync(x => x.Name == dto.Name);

            if (article != null)
            {
                return new BaseResult<bool>()
                {
                    ErrorCode = (int)ErrorCode.ArticleAlreadyExists,
                    ErrorMassage = ErrorMessage.ArticleAlreadyExists
                };
            } 
            article = new Article()
            {
                Keywords = dto.Keywords,
                Name = dto.Name,
                Text = dto.Text
            };

            var subTopic = await _subTopic
                .GetAll()
                .FirstOrDefaultAsync(x => x.Name == dto.SubTopic);

            if (subTopic == null)
            {
                return new BaseResult<bool>()
                {
                    ErrorCode = (int)ErrorCode.SubToticNotFount,
                    ErrorMassage = ErrorMessage.SubToticNotFount
                };
            }
            
            article.SubTopicId = subTopic.Id;

            var createdArticle = await _articleRepository.CreateAsync(article);
            await _authorRepository.SaveChangesAsync();

            article = await _articleRepository.GetAll().FirstOrDefaultAsync(x => x.Name == article.Name);
            
            foreach (var id in dto.AuthorsId)
            {
                await _authorArticleRepository.CreateAsync(new AuthorArticle()
                {
                    ArticleId = article.Id,
                    AuthorId = id
                });
                await _authorArticleRepository.SaveChangesAsync();
            }

            return new BaseResult<bool>()
            {
            };

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new BaseResult<bool>()
            {
                ErrorCode = (int)ErrorCode.InternalServerError,
                ErrorMassage = ErrorMessage.InternalServerError
            };
        }
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