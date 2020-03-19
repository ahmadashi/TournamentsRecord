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
    public class RoleTypeViewModelProvider : IRoleTypeViewModelProvider
    {       

        private readonly IViewModelFactory<RoleTypeViewModel, RoleType> _RoleTypeFactory;
        private readonly IRepository<RoleType> _RoleTypeRepository;

        public RoleTypeViewModelProvider(
            IViewModelFactory<RoleTypeViewModel, RoleType> RoleTypeFactory,
            IRepository<RoleType> RoleTypeRepository)
        {
            _RoleTypeFactory = RoleTypeFactory;
            _RoleTypeRepository = RoleTypeRepository;
        }

        public async Task<IEnumerable<RoleTypeViewModel>> ByAllAsync()
        {
            return await _RoleTypeRepository.QueryAsync<RoleTypeViewModel>(x => true);
        }        
    }
}
