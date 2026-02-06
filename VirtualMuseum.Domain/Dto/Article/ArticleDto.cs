using VirtualMuseum.Domain.Dto.Author;
using VirtualMuseum.Domain.Dto.Feedbacks;
using VirtualMuseum.Domain.Dto.Roles;

namespace VirtualMuseum.Domain.Dto.Article;

public record ArticleDto(
    int Id,
    string Name,
    string Text,
    string Keywords,
    string SubTopic,
    List<AuthorNameDto> Authors,
    List<FeedbackDto> Feedbacks
    );