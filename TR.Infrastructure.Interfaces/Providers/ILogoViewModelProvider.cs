using TR.Infrastructure.ViewModel;

namespace TR.Infrastructure.Interfaces.Providers
{
    public interface ILogoViewModelProvider : 
        IViewModelProviderByActive<LogoViewModel>,
        IViewModelProviderByAll<LogoViewModel>,
        IViewModelProviderById<LogoViewModel>
    { }
}
