using TR.Infrastructure.ViewModel;

namespace TR.Infrastructure.Interfaces.Providers
{
    public interface ITournamentUserViewModelProvider : 
        IViewModelProviderByActive<TournamentUserViewModel>,
        //IViewModelProviderByAll<TournamentUserViewModel>,
        IViewModelProviderById<TournamentUserViewModel>
    { }
}
