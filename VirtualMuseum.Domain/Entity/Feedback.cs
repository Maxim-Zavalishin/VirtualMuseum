using VirtualMuseum.Domain.Interfaces;

namespace VirtualMuseum.Domain.Entity;

/// <summary>
/// Отзыв.
/// </summary>
public class Feedback : IBaseEntity<int>
{
    /// <inheritdoc />
    public int Id { get; set; }

    /// <summary>
    /// Статья, где остави отзыв.
    /// </summary>
    public Article? Article { get; set; }

    /// <summary>
    /// Id статьи, где оставили отзыв.
    /// </summary>
    public int? ArticleId { get; set; }

    /// <summary>
    /// Пользователь, который оставил отзыв.
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// Id пользователя, который оставил отзыв.
    /// </summary>
    public int? UserId { get; set; }
    
    /// <summary>
    /// Текст отзыва.
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// Время оставления отзыва.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}