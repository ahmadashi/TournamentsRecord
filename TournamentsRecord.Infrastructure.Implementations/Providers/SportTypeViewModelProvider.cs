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
    public class SportTypeViewModelProvider : ISportTypeViewModelProvider
    {
        private readonly IViewModelFactory<SportTypeViewModel, SportType> _SportTypeFactory;
        private readonly IRepository<SportType> _SportTypeRepository;

        public SportTypeViewModelProvider(
            IViewModelFactory<SportTypeViewModel, SportType> SportTypeFactory,
            IRepository<SportType> SportTypeRepository)
        {
            _SportTypeFactory = SportTypeFactory;
            _SportTypeRepository = SportTypeRepository;
        }

        public async Task<IEnumerable<SportTypeViewModel>> ByAllAsync()
        {
            return await _SportTypeRepository.QueryAsync<SportTypeViewModel>(x => true);
        }        
    }
}
