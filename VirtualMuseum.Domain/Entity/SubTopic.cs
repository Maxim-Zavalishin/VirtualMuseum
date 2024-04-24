using VirtualMuseum.Domain.Interfaces;

namespace VirtualMuseum.Domain.Entity;

/// <summary>
/// Подтема статьи.
/// </summary>
public class SubTopic : IBaseEntity<int>
{
    /// <inheritdoc />
    public int Id { get; set; }

    /// <summary>
    /// Название подтемы.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание подтемы.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Список статей.
    /// </summary>
    public List<Article>? Articles { get; set; }
}