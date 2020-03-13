using TR.Infrastructure.ViewModel;
namespace TR.Infrastructure.Interfaces.Providers
{
    public interface IUserTypeViewModelProvider :         
        IViewModelProviderByAll<UserTypeViewModel>
        //IViewModelProviderById<UserTypeViewModel>
    { }
}
