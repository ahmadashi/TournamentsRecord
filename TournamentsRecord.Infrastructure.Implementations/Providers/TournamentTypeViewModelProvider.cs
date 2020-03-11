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
    public class TournamentTypeViewModelProvider : ITournamentTypeViewModelProvider
    {       

        private readonly IViewModelFactory<TournamentTypeViewModel, TournamentType> _TournamentTypeFactory;
        private readonly IRepository<TournamentType> _TournamentTypeRepository;

        public TournamentTypeViewModelProvider(
            IViewModelFactory<TournamentTypeViewModel, TournamentType> TournamentTypeFactory,
            IRepository<TournamentType> TournamentTypeRepository)
        {
            _TournamentTypeFactory = TournamentTypeFactory;
            _TournamentTypeRepository = TournamentTypeRepository;
        }

        public async Task<IEnumerable<TournamentTypeViewModel>> ByAllAsync()
        {
            return await _TournamentTypeRepository.QueryAsync<TournamentTypeViewModel>(x => true);
        }        
    }
}
