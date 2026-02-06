using System.Security.AccessControl;
using VirtualMuseum.Domain.Interfaces;

namespace VirtualMuseum.Domain.Entity;

/// <summary>
/// Должность автора.
/// </summary>
public class Position : IBaseEntity<int>
{
    /// <inheritdoc />
    public int Id { get; set; }

    /// <summary>
    /// Название должности.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Список авторов.
    /// </summary>
    public List<AuthorPosition>? AuthorPositions { get; set; }
}