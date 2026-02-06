namespace VirtualMuseum.Domain.Interfaces;

public interface IBaseRepository<TEntity>
{
    /// <summary>
    /// Получение всех записей в таблице.
    /// </summary>
    /// <returns> Список со всеми записями. </returns>
    IQueryable<TEntity> GetAll();

    /// <summary>
    /// Создание новой записи в таблице.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<TEntity> CreateAsync(TEntity entity);

    /// <summary>
    /// Изменение существующей записи.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    TEntity Update(TEntity entity);

    /// <summary>
    /// Удаление существующей записи.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    TEntity Remove(TEntity entity);

    /// <summary>
    /// 
    /// </summary>
    Task SaveChangesAsync();
}