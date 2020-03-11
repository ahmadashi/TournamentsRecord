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
