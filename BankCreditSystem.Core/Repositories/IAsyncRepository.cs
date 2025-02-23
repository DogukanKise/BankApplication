using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace BankCreditSystem.Core.Repositories;

public interface IAsyncRepository<TEntity, TId> where TEntity : Entity<TId>
{
    // Get single entity
    Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);

    // Get list of entities with paging
    Task<PaginationParams<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int pageNumber = 1,
        int pageSize = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);

    // Check if entity exists
    Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>> predicate,
        bool withDeleted = false,
        bool enableTracking=true,
        CancellationToken cancellationToken = default);

    // Add single entity
    Task<TEntity> AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default);

    // Add multiple entities
    Task<ICollection<TEntity>> AddRangeAsync(
        ICollection<TEntity> entities,
        CancellationToken cancellationToken = default);

    // Update single entity
    Task<TEntity> UpdateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default);

    // Update multiple entities
    Task<ICollection<TEntity>> UpdateRangeAsync(
        ICollection<TEntity> entities,
        CancellationToken cancellationToken = default);

    // Delete single entity
    Task<TEntity> DeleteAsync(
        TEntity entity,
        bool permanent = false,
        CancellationToken cancellationToken = default);

    // Delete multiple entities
    Task<ICollection<TEntity>> DeleteRangeAsync(
        ICollection<TEntity> entities,
        bool permanent = false,
        CancellationToken cancellationToken = default);
} 