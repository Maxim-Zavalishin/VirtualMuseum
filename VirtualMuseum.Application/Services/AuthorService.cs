using Microsoft.EntityFrameworkCore;
using VirtualMuseum.Application.Resources;
using VirtualMuseum.Domain.Dto.Article;
using VirtualMuseum.Domain.Dto.Author;
using VirtualMuseum.Domain.Dto.Position;
using VirtualMuseum.Domain.Entity;
using VirtualMuseum.Domain.Enum;
using VirtualMuseum.Domain.Interfaces;
using VirtualMuseum.Domain.Interfaces.Services;
using VirtualMuseum.Domain.Result;

namespace VirtualMuseum.Application.Services;

public  class AuthorService : IAuthorService
{
    private IBaseRepository<Author> _authorRepository;
    private IBaseRepository<Position> _positionRepository;
    private IBaseRepository<AuthorPosition> _authorPositionRepository;
    
    public AuthorService(IBaseRepository<Author> authorRepository, IBaseRepository<Position> positionRepository, IBaseRepository<AuthorPosition> authorPositionRepository)
    {
        _authorRepository = authorRepository;
        _positionRepository = positionRepository;
        _authorPositionRepository = authorPositionRepository;
    }

    public async Task<CollectionResult<AuthorDto>> GetAuthorsAsync()
    {
        try
        {
            var authors = await _authorRepository
                .GetAll()
                .Select(author => new AuthorDto(
                    author.Id,
                    author.Firstname,
                    author.Secondname,
                    author.Lastname,
                    author.AuthorArticles.Count,
                    author.AuthorPositions
                        .Where(authorPosition => authorPosition.Position != null)
                        .Select(authorPosition => new PositionDto(authorPosition.Position.Name)).ToList()
                ))
                .ToListAsync();

            if (authors.Count() == 0)
            {
                return new CollectionResult<AuthorDto>()
                {
                    ErrorMassage = ErrorMessage.AuthorNotFound,
                    ErrorCode = (int)ErrorCode.AuthorNotFound
                };
            }

            return new CollectionResult<AuthorDto>()
            {
                Data = authors
            };
        }
        catch (Exception e)
        {
            return new CollectionResult<AuthorDto>()
            {
                ErrorCode = (int)ErrorCode.InternalServerError,
                ErrorMassage = ErrorMessage.InternalServerError
            };
        }
    }

    public async Task<CollectionResult<GetAuthorDto>> GetAuthorsArticleAsync()
    {
        try
        {
            var authors = await _authorRepository
                .GetAll()
                .Select(author => new GetAuthorDto(
                    author.Id,
                    author.Firstname,
                    author.Secondname,
                    author.Lastname,
                    author.AuthorArticles
                        .Where(authorArticle => authorArticle.Article != null)
                        .Select(authorArticle => new GetListArticleDto(
                            authorArticle.Article.Id,
                            authorArticle.Article.Name,
                            authorArticle.Article.Keywords
                        ))
                        .ToList(),
                    author.AuthorPositions
                        .Where(authorPosition => authorPosition.Position != null)
                        .Select(authorPosition => new PositionDto(authorPosition.Position.Name))
                        .ToList())
                )
                .ToListAsync();

            if (authors.Count == 0)
            {
                return new CollectionResult<GetAuthorDto>()
                {
                    ErrorCode = (int)ErrorCode.AuthorNotFound,
                    ErrorMassage = ErrorMessage.AuthorNotFound
                };
            }

            return new CollectionResult<GetAuthorDto>()
            {
                Data = authors
            };
        }
        catch (Exception e)
        {
            return new CollectionResult<GetAuthorDto>()
            {
                ErrorMassage = $"{ErrorMessage.InternalServerError} {e.ToString()}",
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }
    
    public async Task<BaseResult> CreateAutorAsync(CreateAuthorDto dto)
    {
        try
        {
            var author = new Author()
            {
                Firstname = dto.Firstname,
                Secondname = dto.Secondname,
                Lastname = dto.Lastname
            };

            await _authorRepository.CreateAsync(author);

            author = await _authorRepository
                .GetAll()
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();
                
            foreach (var positionDto in dto.Positions)
            {
                var positionId = _positionRepository
                    .GetAll()
                    .FirstOrDefaultAsync(x => x.Name == positionDto.Name)
                    .Id;
                
                await _authorPositionRepository.CreateAsync(new AuthorPosition()
                {
                    AuthorId = author.Id,
                    PositionId = positionId
                });
            }

            //await _authorPositionRepository.SaveChangesAsync();

            return new BaseResult()
            {
            };

        }
        catch (Exception e)
        {
            return new BaseResult()
            {
                ErrorMassage = ErrorMessage.InternalServerError + e.Message,
                ErrorCode = (int)ErrorCode.InternalServerError
            };
        }
    }

    public Task<BaseResult> DeletePositionAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResult> UpdateAuthorAsync(UpdateAuthorDto dto)
    {
        throw new NotImplementedException();
    }
}