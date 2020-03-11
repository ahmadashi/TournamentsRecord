using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
//using AutoMapper.QueryableExtensions;
using TournamentsRecord.Infrastructure.Interfaces.Inclusions;
using AutoMapper.QueryableExtensions;

namespace TournamentsRecord.DAL.Extensions
{
    public static class TournamentsRecordContextEx
    {   

        public static async Task<IEnumerable<TViewModel>> OrderedQueryAsync<TDomain, TViewModel>(
            this IQueryable<TDomain> set,
            Expression<Func<TDomain, bool>> filterClause,
            int page,
            int pageSize,
            Expression<Func<TDomain, IComparable>> orderBy,
            bool descending = false,
            IInclusionStrategy<TDomain> inclusionStrategy = null) where TDomain : class
        {

            var data = set
                    .Where(filterClause)
                    .AddInclusions(inclusionStrategy)
                    .Order(orderBy, descending)
                    .Skip(pageSize * (page - 1))
                    .Take(pageSize);

            if (typeof(TViewModel) != typeof(TDomain))
            {                
                return await data.ProjectTo<TViewModel>()
                    .ToListAsync();
            }

            return ((IEnumerable<TViewModel>)await data.ToListAsync());
        }


        public static IQueryable<T> AddInclusions<T>(
            this IQueryable<T> queryable,
            IInclusionStrategy<T> inclusionStrategy = null) where T : class
        {
            var func = inclusionStrategy?.InclusionFunc ?? (o => o);

            queryable = func(queryable);
            
            return queryable;
        }

        private static IOrderedQueryable<T> Order<T>(
            this IQueryable<T> queryable,
            Expression<Func<T, IComparable>> orderBy,
            bool descending = false)
        {
            return descending
                ? queryable.OrderByDescending(orderBy)
                : queryable.OrderBy(orderBy);
        }
    }
}