using VirtualMuseum.Domain.Dto.Author;

namespace VirtualMuseum.Domain.Dto.Article;

public record GetArticleDto(
    string Name,
    string Keywords,
    List<AuthorNameDto> Authors
    );