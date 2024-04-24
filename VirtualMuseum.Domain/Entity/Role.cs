using VirtualMuseum.Domain.Interfaces;

namespace VirtualMuseum.Domain.Entity;

/// <summary>
/// Роль пользователя.
/// </summary>
public class Role : IBaseEntity<int>
{
    /// <inheritdoc />
    public int Id { get; set; }
    
    /// <summary>
    /// Название роли.
    /// </summary>
    public string Name { get; set; }
}