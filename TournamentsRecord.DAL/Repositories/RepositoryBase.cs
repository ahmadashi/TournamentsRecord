using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TournamentsRecord.Infrastructure.Interfaces.Inclusions;
using TournamentsRecord.Infrastructure.Interfaces.Infrastructure;
using TournamentsRecord.DAL.Interfaces.Repositories;
using TournamentsRecord.DAL.DataAccess;
using TournamentsRecord.DAL.Extensions;
using TournamentsRecord.Infrastructure.Implementations.Infrastructure;
using TournamentsRecord.DAL.Exception;

namespace TournamentsRecord.DAL.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly IRepositoryExceptionHandler _repositoryExceptionHandler;

        protected readonly TournamentsRecordContext Db;

        public abstract Expression<Func<TournamentsRecordContext, DbSet<T>>> DataSet();

        public abstract Expression<Func<T, IComparable>> DefaultOrderBy();

        public abstract Expression<Func<T, int>> Key();

        private readonly IMapper _mapper;

        protected RepositoryBase(
            TournamentsRecordContext db,
            IRepositoryExceptionHandler repositoryExceptionHandler,
            IMapper mapper)
        {
            _repositoryExceptionHandler = repositoryExceptionHandler;
            _mapper = mapper;
            Db = db;
        }        

        public async Task<IEnumerable<TViewModel>> QueryAsync<TViewModel>(Expression<Func<T, bool>> predicate,
            IInclusionStrategy<T> inclusionStrategy = null)
        {
            using (var db = Db)
            {
                var dataset =
                    DataSet()
                        .Compile()
                        .Invoke(db)
                        .AsNoTracking();

                var data =
                    dataset
                        .Where(predicate)
                        .AddInclusions(inclusionStrategy);

                if (typeof(TViewModel) != typeof(T))
                {
                    return await data.ProjectTo<TViewModel>()
                        .ToListAsync();
                }

                return await Task.FromResult<IEnumerable<TViewModel>>((IEnumerable<TViewModel>)data.ToListAsync());
            }
        }

        public async Task<IPagedList<TViewModel>> QueryAsync<TViewModel>(Expression<Func<T, bool>> predicate, int page, int pageSize, Expression<Func<T, IComparable>> orderBy,
            bool @descending = false, IInclusionStrategy<T> inclusionStrategy = null)
        {
            IPagedList<TViewModel> pagedList = new PagedList<TViewModel>();

            using (var db = Db)
            {
                var dataset =
                    DataSet()
                        .Compile()
                        .Invoke(db)
                        .AsNoTracking();

                pagedList.Count = await
                    dataset
                        .CountAsync(predicate);

                pagedList.Data = await
                    dataset
                        .OrderedQueryAsync<T, TViewModel>(
                            predicate,
                            page,
                            pageSize,
                            orderBy,
                            descending,
                            inclusionStrategy);

                return pagedList;
            }
        }

       
        

        public T AddOrUpdate(T entity)
        {
            try
            {
                using (var db = Db)
                {
                    var selector = BuildSelectorExpression(entity);

                    var dbEntity = DataSet()
                        .Compile()
                        .Invoke(db)
                        .FirstOrDefault(selector);

                    if (dbEntity != null)
                    {
                        db.Entry(dbEntity).State = EntityState.Detached;
                        dbEntity = entity;
                        db.UpdateEntry(dbEntity);
                        db.SaveChanges();
                    }
                    else
                    {
                        DataSet()
                            .Compile()
                            .Invoke(db)
                            .Add(entity);
                        db.SaveChanges();
                        dbEntity = entity;
                    }

                    return dbEntity;
                }
            }
            catch (System.Exception ex)
            {
                throw _repositoryExceptionHandler.Handle(ex);
            }
        }

        public async Task<T> AddOrUpdateAsync(T entity)
        {
            try
            {
                using (var db = Db)
                {
                    var selector = BuildSelectorExpression(entity);
                    var dbEntity = await DataSet()
                        .Compile()
                        .Invoke(db)
                        .FirstOrDefaultAsync(selector);

                    if (dbEntity != null)
                    {
                        db.Entry(dbEntity).State = EntityState.Detached;
                        dbEntity = entity;
                        db.UpdateEntry(dbEntity);
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        await DataSet()
                             .Compile()
                             .Invoke(db)
                             .AddAsync(entity);
                        await db.SaveChangesAsync();
                        dbEntity = entity;
                    }

                    return dbEntity;
                }
            }
            catch (System.Exception ex)
            {
                throw _repositoryExceptionHandler.Handle(ex);
            }
        }

        /// <summary>
        /// AddOrderUpdate converts a ViewModel to the entity First
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public T AddOrUpdateFromViewModel<TViewModel>(TViewModel model)
        {
            try
            {
                var entity = _mapper.Map<T>(model);
                return AddOrUpdate(entity);
            }
            catch (System.Exception ex)
            {
                throw _repositoryExceptionHandler.Handle(ex);
            }
        }

        /// <summary>
        /// AddOrderUpdate converts a ViewModel to the entity First
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<T> AddOrUpdateFromViewModelAsync<TViewModel>(TViewModel model)
        {
            try
            {
                var entity = _mapper.Map<T>(model);
                return await AddOrUpdateAsync(entity);
            }
            catch (System.Exception ex)
            {
                throw _repositoryExceptionHandler.Handle(ex);
            }
        }


        public T Delete(T entity)
        {
            using (var db = Db)
            {
                var selector = BuildSelectorExpression(entity);

                var dbEntity = DataSet()
                    .Compile()
                    .Invoke(db)
                    .FirstOrDefault(selector);

                if (dbEntity != null)
                {
                    db.Entry(dbEntity).State = EntityState.Detached;
                    DataSet()
                        .Compile()
                        .Invoke(db)
                        .Remove(entity);
                    db.SaveChanges();
                }

                return dbEntity;
            }
        }

        public async Task<T> DeleteAsync(T entity)
        {
            using (var db = Db)
            {
                var selector = BuildSelectorExpression(entity);

                var dbEntity = await DataSet()
                    .Compile()
                    .Invoke(db)
                    .FirstOrDefaultAsync(selector);

                if (dbEntity != null)
                {
                    db.Entry(dbEntity).State = EntityState.Detached;
                    DataSet()
                        .Compile()
                        .Invoke(db)
                        .Remove(entity);
                    await db.SaveChangesAsync();
                }

                return dbEntity;
            }
        }

        private Expression<Func<T, bool>> BuildSelectorExpression(T entity)
        {
            var param = Expression.Parameter(typeof(T), "o");

            if (!(Key().Body is MemberExpression member))
            {
                throw new System.Exception($"Repository of type {typeof(T)} has a misconfigured selector expression");
            }

            var memberName = member.Member.Name;

            var exp = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(
                    Expression.Property(param, memberName),
                    Expression.Constant(
                        Key()
                            .Compile()
                            .Invoke(entity),
                        typeof(int))
                ), param
            );

            return exp;
        }

        public async Task<bool> AddRangeAsync(ICollection<T> entitis)
        {
            try
            {
                using (var db = Db)
                {
                    await DataSet()
                         .Compile()
                         .Invoke(db)
                         .AddRangeAsync(entitis);
                    await db.SaveChangesAsync();
                }

                return true;
            }
            catch (System.Exception ex)
            {
                throw _repositoryExceptionHandler.Handle(ex);
            }
        }
    }
}
