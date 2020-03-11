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
    public class LogoViewModelProvider : ILogoViewModelProvider
    {
        //private static readonly IInclusionStrategy<Logo> InclusionStrategy =
        //    new InclusionStrategy<Logo>(
        //        o => o
        //            .Include(u => u.LogoTournaments)
        //    );

        //private static readonly IInclusionStrategy<Logo> InclusionStrategyWithTournament =
        //    new InclusionStrategy<Logo>(
        //        o => o
        //            .Include(u => u.LogoTournaments)                
        //            .ThenInclude(ul => ul.Tournament)
        //            .Include(u => u.Logo)
        //    );

        private readonly IViewModelFactory<LogoViewModel, Logo> _LogoFactory;
        private readonly IRepository<Logo> _LogoRepository;

        public LogoViewModelProvider(
            IViewModelFactory<LogoViewModel, Logo> LogoFactory,
            IRepository<Logo> LogoRepository)
        {
            _LogoFactory = LogoFactory;
            _LogoRepository = LogoRepository;
        }

        public async Task<IEnumerable<LogoViewModel>> ByAllAsync()
        {
            return await _LogoRepository.QueryAsync<LogoViewModel>(x => x.IsActive == true);
        }

        public async Task<IEnumerable<LogoViewModel>> ByActiveAsync(bool isActive)
        {
            //return await _LogoRepository.QueryAsync<LogoViewModel>(new AvatarSpecByActive(isActive));
            return await _LogoRepository.QueryAsync<LogoViewModel>(x => x.IsActive == isActive);
        }

        public async Task<LogoViewModel> ByIdAsync(int id)
        {
            return (await _LogoRepository.QueryAsync<LogoViewModel>(x => x.LogoId == id))
                .FirstOrDefault();
        }

        //public async Task<LogoViewModel> ByIdAsyncWithTournaments(int id)
        //{
        //    return (await _LogoRepository.QueryAsync<LogoViewModel>(x => x.LogoId == id, InclusionStrategyWithTournament))
        //        .FirstOrDefault();
        //}
    }
}
