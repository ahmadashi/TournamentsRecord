using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.Infrastructure.Interfaces.Providers
{
    public interface ITeamViewModelProvider :         
        //IViewModelProviderByAll<TeamViewModel>,
        IViewModelProviderById<TeamViewModel>
    { }
}
