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
    public int? AuthorId { get; set; }

    /// <summary>
    /// Должность.
    /// </summary>
    public Position? Position { get; set; }

    /// <summary>
    /// Id должности.
    /// </summary>
    public int? PositionId { get; set; }
}