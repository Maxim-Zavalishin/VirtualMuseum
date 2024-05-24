using VirtualMuseum.Domain.Dto.Author;

namespace VirtualMuseum.Domain.Dto.Article;

public record CreateArticleDto(
    string Name,
    string Text,
    string Keywords,
    string SubTopic,
    List<AuthorNameDto> Authors
    );