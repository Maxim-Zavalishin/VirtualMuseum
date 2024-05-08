using VirtualMuseum.Domain.Interfaces;

namespace VirtualMuseum.DAL.Repositories;

public  class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    /// <inheritdoc />
    public IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>();
    }

    /// <inheritdoc />
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity", "Параметр \"Entity\" пуст");
        }

        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

        return await Task.FromResult(entity);
    }

    /// <inheritdoc />
    public TEntity Update(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity", "Параметр \"Entity\" пуст");
        }

        _context.Update(entity);

        return entity;
    }

    /// <inheritdoc />
    public TEntity Remove(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity", "Параметр \"Entity\" пуст");
        }

        _context.Remove(entity);
        
        return entity;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}