using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.Infrastructure.Interfaces.Providers
{
    public interface ITournamentViewModelProvider : 
        //IViewModelProviderByActive<TournamentViewModel>,
        //IViewModelProviderByAll<TournamentViewModel>,
        IViewModelProviderById<TournamentViewModel>
    { }
}
