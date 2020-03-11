using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.Infrastructure.Interfaces.Providers
{
    public interface ITournamentUserViewModelProvider : 
        IViewModelProviderByActive<TournamentUserViewModel>,
        //IViewModelProviderByAll<TournamentUserViewModel>,
        IViewModelProviderById<TournamentUserViewModel>
    { }
}
