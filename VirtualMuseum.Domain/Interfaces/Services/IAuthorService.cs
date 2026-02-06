using Microsoft.EntityFrameworkCore;
using VirtualMuseum.Domain.Dto.Article;
using VirtualMuseum.Domain.Dto.Author;
using VirtualMuseum.Domain.Entity;
using VirtualMuseum.Domain.Result;

namespace VirtualMuseum.Domain.Interfaces.Services;

public interface IAuthorService
{
    Task<CollectionResult<AuthorDto>> GetAuthorsAsync();

    Task<CollectionResult<GetAuthorDto>> GetAuthorsArticleAsync();
    
    Task<BaseResult> CreateAutorAsync(CreateAuthorDto dto);

    Task<BaseResult> DeletePositionAsync(int id);

    Task<BaseResult> UpdateAuthorAsync(UpdateAuthorDto dto);
}