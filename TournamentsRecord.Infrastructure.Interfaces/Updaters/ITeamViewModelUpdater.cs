﻿using TournamentsRecord.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TournamentsRecord.Infrastructure.Interfaces.Updaters
{
    public interface ITeamViewModelUpdater : IViewModelUpdater<TeamViewModel>, IViewModelDeleter<TeamViewModel>
    {
        //Task AddRangeAsync(ICollection<UserViewModel> usersViewModels);
    }
}
