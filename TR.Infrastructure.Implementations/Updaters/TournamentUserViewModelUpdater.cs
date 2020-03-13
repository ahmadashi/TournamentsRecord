using TR.DAL.Interfaces.Repositories;
using TR.DAL.Models;
using TR.Infrastructure.Interfaces.Factories;
using TR.Infrastructure.Interfaces.Repositories;
using TR.Infrastructure.Interfaces.Updaters;
using TR.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TR.Infrastructure.Implementations.Updaters
{
    public class TournamentUserViewModelUpdater : ITournamentUserViewModelUpdater
    {
        private readonly IViewModelFactory<TournamentUser, TournamentUserViewModel> _TournamentUserViewModelFactory;
        private readonly IRepository<TournamentUser> _TournamentUserRepository;
        private readonly IReadOnlyRespository<TournamentUserViewModel> _TournamentUserUpdateRepository;

        public TournamentUserViewModelUpdater(
            IViewModelFactory<TournamentUser, TournamentUserViewModel> TournamentUserViewModelFactory,            
            IRepository<TournamentUser> TournamentUserRepository,
            IReadOnlyRespository<TournamentUserViewModel> TournamentUserUpdateRepository
            )
        {
            _TournamentUserViewModelFactory = TournamentUserViewModelFactory;            
            _TournamentUserRepository = TournamentUserRepository;
            _TournamentUserUpdateRepository = TournamentUserUpdateRepository;
        }

        public async Task<TournamentUserViewModel> AddOrUpdateAsync(TournamentUserViewModel TournamentUser)
        {
            var dbTournamentUser = await _TournamentUserRepository.AddOrUpdateAsync(_TournamentUserViewModelFactory.For(TournamentUser));

            TournamentUser.TournamentUserId = dbTournamentUser.TournamentUserId;

            return TournamentUser;
        }

        public async Task<TournamentUserViewModel> DeleteAsync(TournamentUserViewModel TournamentUser)
        {
            var dbTournamentUser = await _TournamentUserRepository.DeleteAsync(_TournamentUserViewModelFactory.For(TournamentUser));

            TournamentUser.TournamentUserId = dbTournamentUser.TournamentUserId;

            return TournamentUser;
        }

        //public async Task<TournamentUserViewModel> MoveTournamentUserToNewSchoolAsync(TournamentUserViewModel TournamentUser, int newSchoolId)
        //{
        //    var parameters = new List<SqlParameter>
        //    {
        //        new SqlParameter("@TournamentUserId", TournamentUser.TournamentUserId),
        //        new SqlParameter("@OldSchoolId", TournamentUser.SchoolId),
        //        new SqlParameter("@NewSchoolId", newSchoolId)

        //    };

        //    await _TournamentUserUpdateRepository.ExecuteNonQueryAsync("[dbo].[uspMoveTournamentUserToNewSchool]", parameters);

        //    TournamentUser.SchoolId = newSchoolId;

        //    return TournamentUser;
        //}

        //public async Task AddRangeAsync(ICollection<TournamentUserViewModel> TournamentUsersViewModels)
        //{
        //    var TournamentUsers = new List<TournamentUser>();

        //    foreach (var TournamentUserViewModel in TournamentUsersViewModels)
        //    {
        //        var TournamentUser = _TournamentUserViewModelFactory.For(TournamentUserViewModel);

        //        TournamentUsers.Add(TournamentUser);
        //    }

        //    await _TournamentUserRepository.AddRangeAsync(TournamentUsers);
        //}


    }
}
