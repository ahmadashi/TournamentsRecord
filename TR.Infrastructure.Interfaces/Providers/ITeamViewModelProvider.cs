using TR.Infrastructure.ViewModel;

namespace TR.Infrastructure.Interfaces.Providers
{
    public interface ITeamViewModelProvider :         
        //IViewModelProviderByAll<TeamViewModel>,
        IViewModelProviderById<TeamViewModel>
    { }
}
