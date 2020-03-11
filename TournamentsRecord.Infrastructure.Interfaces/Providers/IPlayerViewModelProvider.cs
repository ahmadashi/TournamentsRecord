using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.Infrastructure.Interfaces.Providers
{
    public interface IPlayerViewModelProvider : 
        //IViewModelProviderByActive<PlayerViewModel>,
        //IViewModelProviderByAll<PlayerViewModel>,
        IViewModelProviderById<PlayerViewModel>
    { }
}
