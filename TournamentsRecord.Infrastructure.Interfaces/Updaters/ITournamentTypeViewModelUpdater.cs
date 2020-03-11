﻿using TournamentsRecord.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TournamentsRecord.Infrastructure.Interfaces.Updaters
{
    public interface ITournamentTypeViewModelUpdater : IViewModelUpdater<TournamentTypeViewModel>, IViewModelDeleter<TournamentTypeViewModel>
    {
        //Task AddRangeAsync(ICollection<UserViewModel> usersViewModels);
    }
}
