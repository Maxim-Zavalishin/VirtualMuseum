using System.Security.AccessControl;
using VirtualMuseum.Domain.Interfaces;

namespace VirtualMuseum.Domain.Entity;

public class AuthorPosition : IBaseEntity<int>
{
    /// <inheritdoc />
    public int Id { get; set; }

    /// <summary>
    /// Автор.
    /// </summary>
    public Author? Author { get; set; }

    /// <summary>
    /// Id автора.
    /// </summary>
    public int? AutorId { get; set; }
    
    /// <summary>
    /// Статья.
    /// </summary>
    public Article? Article { get; set; }

    /// <summary>
    /// Id статьи.
    /// </summary>
    public int? ArticleId { get; set; }
}