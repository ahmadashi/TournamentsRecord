using TournamentsRecord.DAL.Interfaces.Repositories;
using TournamentsRecord.DAL.Models;
using TournamentsRecord.Infrastructure.Interfaces.Factories;
using TournamentsRecord.Infrastructure.Interfaces.Repositories;
using TournamentsRecord.Infrastructure.Interfaces.Updaters;
using TournamentsRecord.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TournamentsRecord.Infrastructure.Implementations.Updaters
{
    public class TournamentViewModelUpdater : ITournamentViewModelUpdater
    {
        private readonly IViewModelFactory<Tournament, TournamentViewModel> _TournamentViewModelFactory;
        private readonly IRepository<Tournament> _TournamentRepository;
        private readonly IReadOnlyRespository<TournamentViewModel> _TournamentUpdateRepository;

        public TournamentViewModelUpdater(
            IViewModelFactory<Tournament, TournamentViewModel> TournamentViewModelFactory,            
            IRepository<Tournament> TournamentRepository,
            IReadOnlyRespository<TournamentViewModel> TournamentUpdateRepository
            )
        {
            _TournamentViewModelFactory = TournamentViewModelFactory;            
            _TournamentRepository = TournamentRepository;
            _TournamentUpdateRepository = TournamentUpdateRepository;
        }

        public async Task<TournamentViewModel> AddOrUpdateAsync(TournamentViewModel Tournament)
        {
            var dbTournament = await _TournamentRepository.AddOrUpdateAsync(_TournamentViewModelFactory.For(Tournament));

            Tournament.TournamentId = dbTournament.TournamentId;

            return Tournament;
        }

        public async Task<TournamentViewModel> DeleteAsync(TournamentViewModel Tournament)
        {
            var dbTournament = await _TournamentRepository.DeleteAsync(_TournamentViewModelFactory.For(Tournament));

            Tournament.TournamentId = dbTournament.TournamentId;

            return Tournament;
        }

        //public async Task<TournamentViewModel> MoveTournamentToNewSchoolAsync(TournamentViewModel Tournament, int newSchoolId)
        //{
        //    var parameters = new List<SqlParameter>
        //    {
        //        new SqlParameter("@TournamentId", Tournament.TournamentId),
        //        new SqlParameter("@OldSchoolId", Tournament.SchoolId),
        //        new SqlParameter("@NewSchoolId", newSchoolId)

        //    };

        //    await _TournamentUpdateRepository.ExecuteNonQueryAsync("[dbo].[uspMoveTournamentToNewSchool]", parameters);

        //    Tournament.SchoolId = newSchoolId;

        //    return Tournament;
        //}

        //public async Task AddRangeAsync(ICollection<TournamentViewModel> TournamentsViewModels)
        //{
        //    var Tournaments = new List<Tournament>();

        //    foreach (var TournamentViewModel in TournamentsViewModels)
        //    {
        //        var Tournament = _TournamentViewModelFactory.For(TournamentViewModel);

        //        Tournaments.Add(Tournament);
        //    }

        //    await _TournamentRepository.AddRangeAsync(Tournaments);
        //}


    }
}
