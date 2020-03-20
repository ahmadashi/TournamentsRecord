using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TR.DAL.DataAccess;
using TR.DAL.Exception;
using TR.DAL.Repositories;
using TR.Infrastructure.ViewModel;

namespace TR.DAL.Repositories
{
    public class PlayerReadOnlyRespository : ReadOnlyRepositoryBase<PlayerViewModel>
    {
        public PlayerReadOnlyRespository(TRContext db, IRepositoryExceptionHandler repositoryExceptionHandler) : base(db, repositoryExceptionHandler)
        {
        }

        [Obsolete]
        public override Expression<Func<TRContext, DbQuery<PlayerViewModel>>> DataSet() { return d => d.PlayerViewModel; }
    }
   
}
