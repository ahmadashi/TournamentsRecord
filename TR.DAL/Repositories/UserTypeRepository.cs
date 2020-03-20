﻿using System;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TR.DAL.DataAccess;
using TR.DAL.Exception;
using TR.DAL.Models;
using TR.DAL.Repositories;

namespace TR.DAL.Repositories
{
    public class UserTypeRepository : RepositoryBase<UserType>
    {
        public UserTypeRepository(TRContext db, IRepositoryExceptionHandler repositoryExceptionHandler, IMapper mapper) : base(db, repositoryExceptionHandler, mapper) { }

        public override Expression<Func<TRContext, DbSet<UserType>>> DataSet() { return a => a.UserType; }

        public override Expression<Func<UserType, IComparable>> DefaultOrderBy() { return a => a.UserTypeId; }

        public override Expression<Func<UserType, int>> Key() => a => a.UserTypeId;
    }
}