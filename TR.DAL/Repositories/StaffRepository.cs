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
    public class StaffRepository : RepositoryBase<Staff>
    {
        public StaffRepository(TRContext db, IRepositoryExceptionHandler repositoryExceptionHandler, IMapper mapper) : base(db, repositoryExceptionHandler, mapper) { }

        public override Expression<Func<TRContext, DbSet<Staff>>> DataSet() { return a => a.Staff; }

        public override Expression<Func<Staff, IComparable>> DefaultOrderBy() { return a => a.StaffId; }

        public override Expression<Func<Staff, int>> Key() => a => a.StaffId;
    }
}