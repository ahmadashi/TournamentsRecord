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
    public class UserViewModelProvider : IUserViewModelProvider
    {
        private static readonly IInclusionStrategy<User> InclusionStrategy =
            new InclusionStrategy<User>(
                o => o
                    .Include(u => u.Logo)
            );

        private static readonly IInclusionStrategy<User> InclusionStrategyWithTournament =
            new InclusionStrategy<User>(
                o => o
                    .Include(u => u.UserTournaments)                
                    .ThenInclude(ul => ul.Tournament)
                    .Include(u => u.Logo)
            );

        private readonly IViewModelFactory<UserViewModel, User> _userFactory;
        private readonly IRepository<User> _userRepository;

        public UserViewModelProvider(
            IViewModelFactory<UserViewModel, User> userFactory,
            IRepository<User> userRepository)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserViewModel>> ByAllAsync()
        {
            return await _userRepository.QueryAsync<UserViewModel>(x => x.IsActive == true, InclusionStrategy);
        }

        public async Task<IEnumerable<UserViewModel>> ByActiveAsync(bool isActive)
        {
            //return await _userRepository.QueryAsync<UserViewModel>(new AvatarSpecByActive(isActive));
            return await _userRepository.QueryAsync<UserViewModel>(x => x.IsActive == isActive, InclusionStrategy);
        }

        public async Task<UserViewModel> ByIdAsync(int id)
        {
            return (await _userRepository.QueryAsync<UserViewModel>(x => x.UserId == id, InclusionStrategy))
                .FirstOrDefault();
        }

        public async Task<UserViewModel> ByIdAsyncWithTournaments(int id)
        {
            return (await _userRepository.QueryAsync<UserViewModel>(x => x.UserId == id, InclusionStrategyWithTournament))
                .FirstOrDefault();
        }
    }
}
