using TR.DAL.Interfaces.Repositories;
using TR.DAL.Models;
using TR.Infrastructure.Implementations.Inclusions;
using TR.Infrastructure.Interfaces.Factories;
using TR.Infrastructure.Interfaces.Inclusions;
using TR.Infrastructure.Interfaces.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TR.Infrastructure.ViewModel;

namespace TR.Infrastructure.Implementations.Providers
{
    public class UserTypeViewModelProvider : IUserTypeViewModelProvider
    {
        //private static readonly IInclusionStrategy<UserType> InclusionStrategy =
        //    new InclusionStrategy<UserType>(
        //        o => o
        //            .Include(u => u.UserTypeTournaments)
        //    );

        //private static readonly IInclusionStrategy<UserType> InclusionStrategyWithTournament =
        //    new InclusionStrategy<UserType>(
        //        o => o
        //            .Include(u => u.UserTypeTournaments)                
        //            .ThenInclude(ul => ul.Tournament)
        //            .Include(u => u.Logo)
        //    );

        private readonly IViewModelFactory<UserTypeViewModel, UserType> _UserTypeFactory;
        private readonly IRepository<UserType> _UserTypeRepository;

        public UserTypeViewModelProvider(
            IViewModelFactory<UserTypeViewModel, UserType> UserTypeFactory,
            IRepository<UserType> UserTypeRepository)
        {
            _UserTypeFactory = UserTypeFactory;
            _UserTypeRepository = UserTypeRepository;
        }

        public async Task<IEnumerable<UserTypeViewModel>> ByAllAsync()
        {
            return await _UserTypeRepository.QueryAsync<UserTypeViewModel>(x => true);
        }

    }
}
