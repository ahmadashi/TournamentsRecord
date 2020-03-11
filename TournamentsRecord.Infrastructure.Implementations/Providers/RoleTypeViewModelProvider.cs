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
