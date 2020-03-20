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
    public class TournamentUserViewModelProvider : ITournamentUserViewModelProvider
    {       
        //private static readonly IInclusionStrategy<TournamentUser> InclusionStrategyWithUsers =
        //    new InclusionStrategy<TournamentUser>(
        //        o => o                    
        //            .Include(u => u.)                    
        //    );

        private static readonly IInclusionStrategy<TournamentUser> InclusionStrategyWithTournament =
            new InclusionStrategy<TournamentUser>(
                o => o
                    .Include(u => u.Tournament)
                    .ThenInclude(u => u.Logo)
            );

        private readonly IViewModelFactory<TournamentUserViewModel, TournamentUser> _TournamentUserFactory;
        private readonly IRepository<TournamentUser> _TournamentUserRepository;

        public TournamentUserViewModelProvider(
            IViewModelFactory<TournamentUserViewModel, TournamentUser> TournamentUserFactory,
            IRepository<TournamentUser> TournamentUserRepository)
        {
            _TournamentUserFactory = TournamentUserFactory;
            _TournamentUserRepository = TournamentUserRepository;
        }
        

        public async Task<IEnumerable<TournamentUserViewModel>> ByActiveAsync(bool isActive)
        {
            //return await _TournamentUserRepository.QueryAsync<TournamentUserViewModel>(new AvatarSpecByActive(isActive));
            return await _TournamentUserRepository.QueryAsync<TournamentUserViewModel>(x => x.IsActive == isActive);
        }

        public async Task<TournamentUserViewModel> ByIdAsync(int id)
        {
            return (await _TournamentUserRepository.QueryAsync<TournamentUserViewModel>(x => x.TournamentUserId == id))
                .FirstOrDefault();
        }

        //public async Task<IEnumerable<TournamentUserViewModel>> ByTournamentIdAsync(int TournamentId)
        //{
        //    return (await _TournamentUserRepository.QueryAsync<TournamentUserViewModel>(x => x.TournamentId == TournamentId, InclusionStrategyWithUsers));
        //}

        public async Task<IEnumerable<TournamentUserViewModel>> ByUserIdAsync(int UserId)
        {
            return (await _TournamentUserRepository.QueryAsync<TournamentUserViewModel>(x => x.UserId == UserId, InclusionStrategyWithTournament));
        }

    }
}
