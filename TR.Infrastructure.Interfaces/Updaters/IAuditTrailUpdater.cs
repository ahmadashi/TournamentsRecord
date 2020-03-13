using TR.Infrastructure.ViewModel;
using System.Threading.Tasks;

namespace TR.Infrastructure.Interfaces.Updaters
{
    public interface IAuditTrailUpdater
    {
        Task RegisterUpdateAsync<T>(T entity) where T : AuditedObjectViewModel;
        Task RegisterDeletionAsync<T>(T entity) where T : AuditedObjectViewModel;
    }
}