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
    public class LogoRepository : RepositoryBase<Logo>
    {
        public LogoRepository(TRContext db, IRepositoryExceptionHandler repositoryExceptionHandler, IMapper mapper) : base(db, repositoryExceptionHandler, mapper) { }

        public override Expression<Func<TRContext, DbSet<Logo>>> DataSet() { return a => a.Logos; }

        public override Expression<Func<Logo, IComparable>> DefaultOrderBy() { return a => a.LogoId; }

        public override Expression<Func<Logo, int>> Key() => a => a.LogoId;
    }
}