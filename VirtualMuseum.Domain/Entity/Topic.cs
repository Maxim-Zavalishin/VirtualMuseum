using VirtualMuseum.Domain.Interfaces;

namespace VirtualMuseum.Domain.Entity;

/// <summary>
/// Тема статьи.
/// </summary>
public class Topic : IBaseEntity<int>
{
    /// <inheritdoc />
    public int Id { get; set; }

    /// <summary>
    /// Название темы.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание темы.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Список подтем.
    /// </summary>
    public List<SubTopic>? SubTopics { get; set; }
}