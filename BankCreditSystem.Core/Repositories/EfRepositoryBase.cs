using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BankCreditSystem.Core.Repositories;

public class EfRepositoryBase<TEntity, TId, TContext> : IAsyncRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TContext : DbContext
{
    protected readonly TContext Context;

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public async Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Context.Set<TEntity>();
        
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        
        if (include != null)
            queryable = include(queryable);
        if(!withDeleted)
            queryable = queryable.Where(x => x.DeletedDate == null);
        return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<PaginationParams<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int pageNumber = 1,
        int pageSize = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Context.Set<TEntity>();

        if (!enableTracking)
            queryable = queryable.AsNoTracking();

        if (include != null)
            queryable = include(queryable);

        if (predicate != null)
            queryable = queryable.Where(predicate);

        if (orderBy != null)
            queryable = orderBy(queryable);

        if(!withDeleted)
            queryable = queryable.Where(x => x.DeletedDate == null);

        int totalCount = await queryable.CountAsync(cancellationToken);

        var items = await queryable
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PaginationParams<TEntity>(items, totalCount, pageNumber, pageSize);
    }

    public async Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>> predicate,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Context.Set<TEntity>();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();

        if (predicate != null)
            queryable = queryable.Where(predicate);

        if(!withDeleted)
            queryable = queryable.Where(x => x.DeletedDate == null);

        return await queryable.AnyAsync(cancellationToken);
    }

    public async Task<TEntity> AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<ICollection<TEntity>> AddRangeAsync(
        ICollection<TEntity> entities,
        CancellationToken cancellationToken = default)
    {
        await Context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entities;
    }

    public async Task<TEntity> UpdateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        Context.Set<TEntity>().Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<ICollection<TEntity>> UpdateRangeAsync(
        ICollection<TEntity> entities,
        CancellationToken cancellationToken = default)
    {
        Context.Set<TEntity>().UpdateRange(entities);
        await Context.SaveChangesAsync(cancellationToken);
        return entities;
    }

    public async Task<TEntity> DeleteAsync(
        TEntity entity,
        bool permanent = false,
        CancellationToken cancellationToken = default)
    {
        if(!permanent)
        {
            entity.DeletedDate = DateTime.UtcNow;
            Context.Set<TEntity>().Update(entity);
        }
        else
            Context.Set<TEntity>().Remove(entity);

        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<ICollection<TEntity>> DeleteRangeAsync(
        ICollection<TEntity> entities,
        bool permanent = false,
        CancellationToken cancellationToken = default)
    {
        if(!permanent){
            foreach(var entity in entities){
                entity.DeletedDate = DateTime.UtcNow;
                Context.Set<TEntity>().UpdateRange(entity);
            }
        }
        else{
            Context.Set<TEntity>().RemoveRange(entities);
        }
        await Context.SaveChangesAsync(cancellationToken);
        return entities;
    }
}   