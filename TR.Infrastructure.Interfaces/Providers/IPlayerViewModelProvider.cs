using TR.Infrastructure.ViewModel;

namespace TR.Infrastructure.Interfaces.Providers
{
    public interface IPlayerViewModelProvider : 
        //IViewModelProviderByActive<PlayerViewModel>,
        //IViewModelProviderByAll<PlayerViewModel>,
        IViewModelProviderById<PlayerViewModel>
    { }
}
