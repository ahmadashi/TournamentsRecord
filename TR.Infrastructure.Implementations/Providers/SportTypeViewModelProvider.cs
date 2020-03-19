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
