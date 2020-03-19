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
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(TRContext db, IRepositoryExceptionHandler repositoryExceptionHandler, IMapper mapper) : base(db, repositoryExceptionHandler, mapper) { }

        public override Expression<Func<TRContext, DbSet<User>>> DataSet() { return a => a.Users; }

        public override Expression<Func<User, IComparable>> DefaultOrderBy() { return a => a.UserId; }

        public override Expression<Func<User, int>> Key() => a => a.UserId;
    }
}