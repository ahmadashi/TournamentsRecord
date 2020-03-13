using TR.Infrastructure.ViewModel;

namespace TR.Infrastructure.Interfaces.Providers
{
    public interface IUserViewModelProvider : 
        IViewModelProviderByActive<UserViewModel>,
        IViewModelProviderByAll<UserViewModel>,
        IViewModelProviderById<UserViewModel>
    { }
}
