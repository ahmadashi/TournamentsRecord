using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TournamentsRecord.Infrastructure.Interfaces.Repositories
{
    public interface IReadOnlyRespository<TViewModel>
    {
        Task<IList<TViewModel>> ExecuteCommandAsync(string command, IList<SqlParameter> sqlParams);
        Task<TType> ExecuteScalarCommandAsync<TType>(string command, IList<SqlParameter> sqlParams);
        Task ExecuteNonQueryAsync(string command, IList<SqlParameter> sqlParams);
        Task<IList<TViewModel>> ExecuteCommandAsync(string command);

    }
}
