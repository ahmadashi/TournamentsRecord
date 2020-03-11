﻿using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.Infrastructure.Interfaces.Providers
{
    public interface ILogoViewModelProvider : 
        IViewModelProviderByActive<LogoViewModel>,
        IViewModelProviderByAll<LogoViewModel>,
        IViewModelProviderById<LogoViewModel>
    { }
}