using TournamentsRecord.DAL.Interfaces.Repositories;
using TournamentsRecord.DAL.Models;
using TournamentsRecord.Infrastructure.Implementations.Inclusions;
using TournamentsRecord.Infrastructure.Interfaces.Factories;
using TournamentsRecord.Infrastructure.Interfaces.Inclusions;
using TournamentsRecord.Infrastructure.Interfaces.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.Infrastructure.Implementations.Providers
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
