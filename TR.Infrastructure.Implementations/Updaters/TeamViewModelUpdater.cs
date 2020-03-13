using TR.DAL.Interfaces.Repositories;
using TR.DAL.Models;
using TR.Infrastructure.Interfaces.Factories;
using TR.Infrastructure.Interfaces.Repositories;
using TR.Infrastructure.Interfaces.Updaters;
using TR.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SportTeam.Infrastructure.Implementations.Updaters
{
    public class TeamViewModelUpdater : ITeamViewModelUpdater
    {
        private readonly IViewModelFactory<Team, TeamViewModel> _TeamViewModelFactory;
        private readonly IRepository<Team> _TeamRepository;
        private readonly IReadOnlyRespository<TeamViewModel> _TeamUpdateRepository;

        public TeamViewModelUpdater(
            IViewModelFactory<Team, TeamViewModel> TeamViewModelFactory,            
            IRepository<Team> TeamRepository,
            IReadOnlyRespository<TeamViewModel> TeamUpdateRepository
            )
        {
            _TeamViewModelFactory = TeamViewModelFactory;            
            _TeamRepository = TeamRepository;
            _TeamUpdateRepository = TeamUpdateRepository;
        }

        public async Task<TeamViewModel> AddOrUpdateAsync(TeamViewModel Team)
        {
            var dbTeam = await _TeamRepository.AddOrUpdateAsync(_TeamViewModelFactory.For(Team));

            Team.TeamId = dbTeam.TeamId;

            return Team;
        }

        public async Task<TeamViewModel> DeleteAsync(TeamViewModel Team)
        {
            var dbTeam = await _TeamRepository.DeleteAsync(_TeamViewModelFactory.For(Team));

            Team.TeamId = dbTeam.TeamId;

            return Team;
        }

        //public async Task<TeamViewModel> MoveTeamToNewSchoolAsync(TeamViewModel Team, int newSchoolId)
        //{
        //    var parameters = new List<SqlParameter>
        //    {
        //        new SqlParameter("@TeamId", Team.TeamId),
        //        new SqlParameter("@OldSchoolId", Team.SchoolId),
        //        new SqlParameter("@NewSchoolId", newSchoolId)

        //    };

        //    await _TeamUpdateRepository.ExecuteNonQueryAsync("[dbo].[uspMoveTeamToNewSchool]", parameters);

        //    Team.SchoolId = newSchoolId;

        //    return Team;
        //}

        //public async Task AddRangeAsync(ICollection<TeamViewModel> TeamsViewModels)
        //{
        //    var Teams = new List<Team>();

        //    foreach (var TeamViewModel in TeamsViewModels)
        //    {
        //        var Team = _TeamViewModelFactory.For(TeamViewModel);

        //        Teams.Add(Team);
        //    }

        //    await _TeamRepository.AddRangeAsync(Teams);
        //}


    }
}
