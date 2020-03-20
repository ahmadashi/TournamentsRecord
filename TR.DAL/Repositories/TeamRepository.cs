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
    public class TeamRepository : RepositoryBase<Team>
    {
        public TeamRepository(TRContext db, IRepositoryExceptionHandler repositoryExceptionHandler, IMapper mapper) : base(db, repositoryExceptionHandler, mapper) { }

        public override Expression<Func<TRContext, DbSet<Team>>> DataSet() { return a => a.Teams; }

        public override Expression<Func<Team, IComparable>> DefaultOrderBy() { return a => a.TeamId; }

        public override Expression<Func<Team, int>> Key() => a => a.TeamId;
    }
}