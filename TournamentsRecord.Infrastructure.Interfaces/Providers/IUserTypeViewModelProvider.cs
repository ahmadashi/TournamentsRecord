using TournamentsRecord.Infrastructure.ViewModel;
namespace TournamentsRecord.Infrastructure.Interfaces.Providers
{
    public interface IUserTypeViewModelProvider :         
        IViewModelProviderByAll<UserTypeViewModel>
        //IViewModelProviderById<UserTypeViewModel>
    { }
}
