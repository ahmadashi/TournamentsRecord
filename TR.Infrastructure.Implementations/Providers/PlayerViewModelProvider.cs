using TR.Infrastructure.Interfaces.Repositories;
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
    public class PlayerViewModelProvider : IPlayerViewModelProvider
    {
        private static readonly IInclusionStrategy<Player> InclusionStrategy =
            new InclusionStrategy<Player>(
                o => o
                    .Include(u => u.Logo)
            );

        private static readonly IInclusionStrategy<Player> InclusionStrategyWithTeam =
            new InclusionStrategy<Player>(
                o => o
                    .Include(u => u.Team)
                    .ThenInclude(ul => ul.Logo)
                    .Include(u => u.Logo)
            );

        private readonly IViewModelFactory<PlayerViewModel, Player> _PlayerFactory;
        private readonly IRepository<Player> _PlayerRepository;

        public PlayerViewModelProvider(
            IViewModelFactory<PlayerViewModel, Player> PlayerFactory,
            IRepository<Player> PlayerRepository)
        {
            _PlayerFactory = PlayerFactory;
            _PlayerRepository = PlayerRepository;
        }
                
        public async Task<PlayerViewModel> ByIdAsync(int id)
        {
            return (await _PlayerRepository.QueryAsync<PlayerViewModel>(x => x.PlayerId == id, InclusionStrategy))
                .FirstOrDefault();
        }

        public async Task<IEnumerable<PlayerViewModel>> ByTeamIdAsync(int TeamId)
        {
            return (await _PlayerRepository.QueryAsync<PlayerViewModel>(x => x.TeamId == TeamId, InclusionStrategyWithTeam));
        }      

    }
}
