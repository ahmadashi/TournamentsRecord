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
    public class RoleTypeRepository : RepositoryBase<RoleType>
    {
        public RoleTypeRepository(TRContext db, IRepositoryExceptionHandler repositoryExceptionHandler, IMapper mapper) : base(db, repositoryExceptionHandler, mapper) { }

        public override Expression<Func<TRContext, DbSet<RoleType>>> DataSet() { return a => a.RoleType; }

        public override Expression<Func<RoleType, IComparable>> DefaultOrderBy() { return a => a.RoleTypeId; }

        public override Expression<Func<RoleType, int>> Key() => a => a.RoleTypeId;
    }
}