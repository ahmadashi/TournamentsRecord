using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace TR.DAL.Exception
{
    public class RepositoryExceptionHandler : IRepositoryExceptionHandler
    {
        private readonly int[] _sqlErrorDuplicate = { 0xa29, 0xa43 };

        public System.Exception Handle(System.Exception ex)
        {
            var exception = ex;

            if (ex is DbUpdateException)
                exception = ex.InnerException ?? ex;

            if (exception is SqlException e)
            {
                if (_sqlErrorDuplicate.Contains(e.Number))
                {
                    throw new DuplicateKeyException(exception);
                }
            }

            return ex;
        }
    }

    public class DuplicateKeyException : System.Exception
    {
        public DuplicateKeyException(System.Exception innerException) : base("The record could not be inserted", innerException) { }
    }
}
