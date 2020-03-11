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
    public class TeamViewModelProvider : ITeamViewModelProvider
    {
        private static readonly IInclusionStrategy<Team> InclusionStrategy =
            new InclusionStrategy<Team>(
                o => o
                    .Include(u => u.Logo)
            );

        private static readonly IInclusionStrategy<Team> InclusionStrategyAll =
            new InclusionStrategy<Team>(
                o => o
                    .Include(u => u.Players)
                    .Include(u => u.Staff)                    
                    .Include(u => u.Logo)
            );

        private readonly IViewModelFactory<TeamViewModel, Team> _teamFactory;
        private readonly IRepository<Team> _teamRepository;

        public TeamViewModelProvider(
            IViewModelFactory<TeamViewModel, Team> teamFactory,
            IRepository<Team> teamRepository)
        {
            _teamFactory = teamFactory;
            _teamRepository = teamRepository;
        }

        //public async Task<IEnumerable<TeamViewModel>> ByAllAsync()
        //{
        //    return await _teamRepository.QueryAsync<TeamViewModel>();
        //}

        //public async Task<IEnumerable<TeamViewModel>> ByActiveAsync(bool isActive)
        //{
        //    //return await _TeamRepository.QueryAsync<TeamViewModel>(new AvatarSpecByActive(isActive));
        //    return await _teamRepository.QueryAsync<TeamViewModel>(x => x.IsActive == isActive);
        //}

        public async Task<TeamViewModel> ByIdAsync(int id)
        {
            return (await _teamRepository.QueryAsync<TeamViewModel>(x => x.TeamId == id))
                .FirstOrDefault();
        }

        public async Task<IEnumerable<TeamViewModel>> ByTournamentIdAsync(int TournamentId)
        {
            return (await _teamRepository.QueryAsync<TeamViewModel>(x => x.TournamenttId == TournamentId));
        }

        public async Task<TeamViewModel> ByIdAsyncWithMembers(int id)
        {
            return (await _teamRepository.QueryAsync<TeamViewModel>(x => x.TeamId == id, InclusionStrategyAll))
                .FirstOrDefault();
        }
    }
}
