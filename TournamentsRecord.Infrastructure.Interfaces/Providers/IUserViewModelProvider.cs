using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.Infrastructure.Interfaces.Providers
{
    public interface IUserViewModelProvider : 
        IViewModelProviderByActive<UserViewModel>,
        IViewModelProviderByAll<UserViewModel>,
        IViewModelProviderById<UserViewModel>
    { }
}
