using TR.Infrastructure.ViewModel;

namespace TR.Infrastructure.Interfaces.Providers
{
    public interface ITournamentTypeViewModelProvider :         
        IViewModelProviderByAll<TournamentTypeViewModel>
        //IViewModelProviderById<TournamentTypeViewModel>
    { }
}
