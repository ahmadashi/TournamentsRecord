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
    public class TournamentRepository : RepositoryBase<Tournament>
    {
        public TournamentRepository(TRContext db, IRepositoryExceptionHandler repositoryExceptionHandler, IMapper mapper) : base(db, repositoryExceptionHandler, mapper) { }

        public override Expression<Func<TRContext, DbSet<Tournament>>> DataSet() { return a => a.Tournaments; }

        public override Expression<Func<Tournament, IComparable>> DefaultOrderBy() { return a => a.TournamentId; }

        public override Expression<Func<Tournament, int>> Key() => a => a.TournamentId;
    }
}