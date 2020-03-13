using TR.Infrastructure.ViewModel;

namespace TR.Infrastructure.Interfaces.Providers
{
    public interface ITournamentViewModelProvider : 
        //IViewModelProviderByActive<TournamentViewModel>,
        //IViewModelProviderByAll<TournamentViewModel>,
        IViewModelProviderById<TournamentViewModel>
    { }
}
