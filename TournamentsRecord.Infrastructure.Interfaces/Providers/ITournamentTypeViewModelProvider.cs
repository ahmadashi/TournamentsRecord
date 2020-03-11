using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.Infrastructure.Interfaces.Providers
{
    public interface ITournamentTypeViewModelProvider :         
        IViewModelProviderByAll<TournamentTypeViewModel>
        //IViewModelProviderById<TournamentTypeViewModel>
    { }
}
