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
    public class PlayerViewModelUpdater : IPlayerViewModelUpdater
    {
        private readonly IViewModelFactory<Player, PlayerViewModel> _PlayerViewModelFactory;
        private readonly IRepository<Player> _PlayerRepository;
        private readonly IReadOnlyRespository<PlayerViewModel> _PlayerUpdateRepository;

        public PlayerViewModelUpdater(
            IViewModelFactory<Player, PlayerViewModel> PlayerViewModelFactory,            
            IRepository<Player> PlayerRepository,
            IReadOnlyRespository<PlayerViewModel> PlayerUpdateRepository
            )
        {
            _PlayerViewModelFactory = PlayerViewModelFactory;            
            _PlayerRepository = PlayerRepository;
            _PlayerUpdateRepository = PlayerUpdateRepository;
        }

        public async Task<PlayerViewModel> AddOrUpdateAsync(PlayerViewModel Player)
        {
            var dbPlayer = await _PlayerRepository.AddOrUpdateAsync(_PlayerViewModelFactory.For(Player));

            Player.PlayerId = dbPlayer.PlayerId;

            return Player;
        }

        public async Task<PlayerViewModel> DeleteAsync(PlayerViewModel Player)
        {
            var dbPlayer = await _PlayerRepository.DeleteAsync(_PlayerViewModelFactory.For(Player));

            Player.PlayerId = dbPlayer.PlayerId;

            return Player;
        }

        //public async Task<PlayerViewModel> MovePlayerToNewSchoolAsync(PlayerViewModel Player, int newSchoolId)
        //{
        //    var parameters = new List<SqlParameter>
        //    {
        //        new SqlParameter("@PlayerId", Player.PlayerId),
        //        new SqlParameter("@OldSchoolId", Player.SchoolId),
        //        new SqlParameter("@NewSchoolId", newSchoolId)

        //    };

        //    await _PlayerUpdateRepository.ExecuteNonQueryAsync("[dbo].[uspMovePlayerToNewSchool]", parameters);

        //    Player.SchoolId = newSchoolId;

        //    return Player;
        //}

        //public async Task AddRangeAsync(ICollection<PlayerViewModel> PlayersViewModels)
        //{
        //    var Players = new List<Player>();

        //    foreach (var PlayerViewModel in PlayersViewModels)
        //    {
        //        var Player = _PlayerViewModelFactory.For(PlayerViewModel);

        //        Players.Add(Player);
        //    }

        //    await _PlayerRepository.AddRangeAsync(Players);
        //}


    }
}
