using VirtualMuseum.Domain.Interfaces;

namespace VirtualMuseum.Domain.Entity;

/// <summary>
/// Статья
/// </summary>
public class Article : IBaseEntity<int>
{
    /// <inheritdoc />
    public int Id { get; set; }

    /// <summary>
    /// Название статьи.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Текст статьи.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Ключевые слова.
    /// </summary>
    public string Keywords { get; set; }

    /// <summary>
    /// Подтема статьи.
    /// </summary>
    public SubTopic? SubTopic { get; set; }

    /// <summary>
    /// Id подтемы статьи.
    /// </summary>
    public int? SubTopicId { get; set; }

    /// <summary>
    /// Список авторов статьи;
    /// </summary>
    public List<AuthorArticle>? AuthorArticles { get; set; }

    /// <summary>
    /// Список отзывов к статье.
    /// </summary>
    public List<Feedback>? Feedbacks { get; set; }
}