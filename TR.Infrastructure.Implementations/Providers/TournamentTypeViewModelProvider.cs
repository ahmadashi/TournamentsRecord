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
