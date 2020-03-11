using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.Infrastructure.Interfaces.Providers
{
    public interface ISportTypeViewModelProvider :         
        IViewModelProviderByAll<SportTypeViewModel>
        //IViewModelProviderById<SportTypeViewModel>
    { }
}
