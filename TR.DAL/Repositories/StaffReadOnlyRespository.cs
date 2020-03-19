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
    public class StaffReadOnlyRespository : ReadOnlyRepositoryBase<StaffViewModel>
    {
        public StaffReadOnlyRespository(TRContext db, IRepositoryExceptionHandler repositoryExceptionHandler) : base(db, repositoryExceptionHandler)
        {
        }

        [Obsolete]
        public override Expression<Func<TRContext, DbQuery<StaffViewModel>>> DataSet() { return d => d.StaffViewModel; }
    }
   
}
