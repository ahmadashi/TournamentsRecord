using TournamentsRecord.Infrastructure.ViewModel;
using System.Threading.Tasks;

namespace TournamentsRecord.Infrastructure.Interfaces.Updaters
{
    public interface IAuditTrailUpdater
    {
        Task RegisterUpdateAsync<T>(T entity) where T : AuditedObjectViewModel;
        Task RegisterDeletionAsync<T>(T entity) where T : AuditedObjectViewModel;
    }
}