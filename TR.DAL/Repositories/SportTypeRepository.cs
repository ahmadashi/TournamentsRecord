using System;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TR.DAL.DataAccess;
using TR.DAL.Exception;
using TR.DAL.Models;
using TR.DAL.Repositories;

namespace TR.DAL.Repositories
{
    public class SportTypeRepository : RepositoryBase<SportType>
    {
        public SportTypeRepository(TRContext db, IRepositoryExceptionHandler repositoryExceptionHandler, IMapper mapper) : base(db, repositoryExceptionHandler, mapper) { }

        public override Expression<Func<TRContext, DbSet<SportType>>> DataSet() { return a => a.SportType; }

        public override Expression<Func<SportType, IComparable>> DefaultOrderBy() { return a => a.SportTypeId; }

        public override Expression<Func<SportType, int>> Key() => a => a.SportTypeId;
    }
}