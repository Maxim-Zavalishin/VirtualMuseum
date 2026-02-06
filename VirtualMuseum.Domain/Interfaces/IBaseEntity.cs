namespace VirtualMuseum.Domain.Interfaces;

/// <summary>
/// Базовая сущность.
/// </summary>
/// <typeparam name="TEntity"> Тип данных Id. </typeparam>
public interface IBaseEntity<TEntity>
{
    /// <summary>
    /// Уникальный идентификатор.
    /// </summary>
    public TEntity Id { get; set; }
}