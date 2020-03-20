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
    public class StaffViewModelProvider : IStaffViewModelProvider
    {
        private static readonly IInclusionStrategy<Staff> InclusionStrategy =
            new InclusionStrategy<Staff>(
                o => o
                    .Include(u => u.Logo)
            );

        private static readonly IInclusionStrategy<Staff> InclusionStrategyWithTeam =
            new InclusionStrategy<Staff>(
                o => o
                    .Include(u => u.Team)
                    .ThenInclude(ul => ul.Logo)
                    .Include(u => u.Logo)
            );

        private readonly IViewModelFactory<StaffViewModel, Staff> _StaffFactory;
        private readonly IRepository<Staff> _StaffRepository;

        public StaffViewModelProvider(
            IViewModelFactory<StaffViewModel, Staff> StaffFactory,
            IRepository<Staff> StaffRepository)
        {
            _StaffFactory = StaffFactory;
            _StaffRepository = StaffRepository;
        }        

        public async Task<StaffViewModel> ByIdAsync(int id)
        {
            return (await _StaffRepository.QueryAsync<StaffViewModel>(x => x.StaffId == id, InclusionStrategy))
                .FirstOrDefault();
        }

        public async Task<IEnumerable<StaffViewModel>> ByTeamIdAsync(int TeamId)
        {
            return (await _StaffRepository.QueryAsync<StaffViewModel>(x => x.TeamId == TeamId));
        }        
    }
}
