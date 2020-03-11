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
    public class TournamentViewModelProvider : ITournamentViewModelProvider
    {
        private static readonly IInclusionStrategy<Tournament> InclusionStrategy =
            new InclusionStrategy<Tournament>(
                o => o
                    .Include(u => u.LogId)
            );

        private static readonly IInclusionStrategy<Tournament> InclusionStrategyWithTeams =
            new InclusionStrategy<Tournament>(
                o => o
                    .Include(u => u.Teams)                
                    .ThenInclude(ul => ul.Logo)
                    .Include(u => u.Logo)
            );

        private readonly IViewModelFactory<TournamentViewModel, Tournament> _TournamentFactory;
        private readonly IRepository<Tournament> _TournamentRepository;

        public TournamentViewModelProvider(
            IViewModelFactory<TournamentViewModel, Tournament> TournamentFactory,
            IRepository<Tournament> TournamentRepository)
        {
            _TournamentFactory = TournamentFactory;
            _TournamentRepository = TournamentRepository;
        }        

        public async Task<IEnumerable<TournamentViewModel>> ByActiveAsync(TournamentStatus TournamentStatus)
        {            
            return await _TournamentRepository.QueryAsync<TournamentViewModel>(x => x.TournamentStatus == TournamentStatus, InclusionStrategy);
        }       

        public async Task<TournamentViewModel> ByIdAsync(int id)
        {
            return (await _TournamentRepository.QueryAsync<TournamentViewModel>(x => x.TournamentId == id, InclusionStrategy))
                .FirstOrDefault();
        }

        public async Task<TournamentViewModel> ByIdAsyncWithTeams(int id)
        {
            return (await _TournamentRepository.QueryAsync<TournamentViewModel>(x => x.TournamentId == id, InclusionStrategyWithTeams))
                .FirstOrDefault();
        }
    }
}
