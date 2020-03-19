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
