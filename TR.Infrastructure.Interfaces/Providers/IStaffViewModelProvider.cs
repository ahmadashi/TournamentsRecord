using TR.Infrastructure.ViewModel;

namespace TR.Infrastructure.Interfaces.Providers
{
    public interface IStaffViewModelProvider : 
        //IViewModelProviderByActive<StaffViewModel>,
        //IViewModelProviderByAll<StaffViewModel>,
        IViewModelProviderById<StaffViewModel>
    { }
}
