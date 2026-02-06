using VirtualMuseum.Domain.Dto.Author;

namespace VirtualMuseum.Domain.Dto.Article;

public record GetArticleDto(
    int Id,
    string Name,
    string Keywords,
    List<AuthorNameDto> Authors
    );