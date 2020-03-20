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
    public class PlayerRepository : RepositoryBase<Player>
    {
        public PlayerRepository(TRContext db, IRepositoryExceptionHandler repositoryExceptionHandler, IMapper mapper) : base(db, repositoryExceptionHandler, mapper) { }

        public override Expression<Func<TRContext, DbSet<Player>>> DataSet() { return a => a.Players; }

        public override Expression<Func<Player, IComparable>> DefaultOrderBy() { return a => a.PlayerId; }

        public override Expression<Func<Player, int>> Key() => a => a.PlayerId;
    }
}