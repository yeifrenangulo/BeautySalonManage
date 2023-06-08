using Ardalis.Specification.EntityFrameworkCore;
using BeautySalonManage.Application.Common.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BeautySalonManage.Infrastructure.Persistence.Repositories;

public class RepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
{
    private readonly DbContext _dbContext;

    public RepositoryAsync(DbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task DeleteRangeAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        IEnumerable<T> entities = _dbContext.Set<T>().Where(expression).AsEnumerable();
        await base.DeleteRangeAsync(entities, cancellationToken);
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(expression, cancellationToken);
    }

    public async Task InsertAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
    }

    public async Task InsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<T>().AddRangeAsync(entities, cancellationToken);
    }

    public async Task<List<T>> ListAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().Where(expression).ToListAsync(cancellationToken);
    }
}
