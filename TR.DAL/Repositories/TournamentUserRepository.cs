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
    public class TournamentUserRepository : RepositoryBase<TournamentUser>
    {
        public TournamentUserRepository(TRContext db, IRepositoryExceptionHandler repositoryExceptionHandler, IMapper mapper) : base(db, repositoryExceptionHandler, mapper) { }

        public override Expression<Func<TRContext, DbSet<TournamentUser>>> DataSet() { return a => a.TournamentUsers; }

        public override Expression<Func<TournamentUser, IComparable>> DefaultOrderBy() { return a => a.TournamentUserId; }

        public override Expression<Func<TournamentUser, int>> Key() => a => a.TournamentUserId;
    }
}