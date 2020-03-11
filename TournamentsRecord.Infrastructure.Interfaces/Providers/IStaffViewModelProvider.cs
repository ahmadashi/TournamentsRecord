using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.Infrastructure.Interfaces.Providers
{
    public interface IStaffViewModelProvider : 
        //IViewModelProviderByActive<StaffViewModel>,
        //IViewModelProviderByAll<StaffViewModel>,
        IViewModelProviderById<StaffViewModel>
    { }
}
