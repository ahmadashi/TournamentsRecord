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
    public class TournamentTypeRepository : RepositoryBase<TournamentType>
    {
        public TournamentTypeRepository(TRContext db, IRepositoryExceptionHandler repositoryExceptionHandler, IMapper mapper) : base(db, repositoryExceptionHandler, mapper) { }

        public override Expression<Func<TRContext, DbSet<TournamentType>>> DataSet() { return a => a.TournamentType; }

        public override Expression<Func<TournamentType, IComparable>> DefaultOrderBy() { return a => a.TournamentTypeId; }

        public override Expression<Func<TournamentType, int>> Key() => a => a.TournamentTypeId;
    }
}