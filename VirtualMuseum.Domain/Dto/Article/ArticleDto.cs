using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.Domain.Dto.Article;

public record ArticleDto(
    string Name,
    string Text,
    string Keywords,
    string SubTopic,
    List<AuthorArticle> Authors,
    List<Feedback> Feedbacks
    );