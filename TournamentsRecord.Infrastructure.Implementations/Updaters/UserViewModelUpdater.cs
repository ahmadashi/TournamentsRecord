using TournamentsRecord.DAL.Interfaces.Repositories;
using TournamentsRecord.DAL.Models;
using TournamentsRecord.Infrastructure.Interfaces.Factories;
using TournamentsRecord.Infrastructure.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TournamentsRecord.Infrastructure.Interfaces.Updaters;
using TournamentsRecord.Infrastructure.ViewModel;

namespace TournamentsRecord.Infrastructure.Implementations.Updaters
{
    public class UserViewModelUpdater : IUserViewModelUpdater
    {
        private readonly IViewModelFactory<User, UserViewModel> _userViewModelFactory;
        private readonly IRepository<User> _userRepository;
        private readonly IReadOnlyRespository<UserViewModel> _userUpdateRepository;

        public UserViewModelUpdater(
            IViewModelFactory<User, UserViewModel> userViewModelFactory,            
            IRepository<User> userRepository,
            IReadOnlyRespository<UserViewModel> userUpdateRepository
            )
        {
            _userViewModelFactory = userViewModelFactory;            
            _userRepository = userRepository;
            _userUpdateRepository = userUpdateRepository;
        }

        public async Task<UserViewModel> AddOrUpdateAsync(UserViewModel user)
        {
            var dbUser = await _userRepository.AddOrUpdateAsync(_userViewModelFactory.For(user));

            user.UserId = dbUser.UserId;

            return user;
        }

        public async Task<UserViewModel> DeleteAsync(UserViewModel user)
        {
            var dbUser = await _userRepository.DeleteAsync(_userViewModelFactory.For(user));

            user.UserId = dbUser.UserId;

            return user;
        }

        //public async Task<UserViewModel> MoveUserToNewSchoolAsync(UserViewModel user, int newSchoolId)
        //{
        //    var parameters = new List<SqlParameter>
        //    {
        //        new SqlParameter("@UserId", user.UserId),
        //        new SqlParameter("@OldSchoolId", user.SchoolId),
        //        new SqlParameter("@NewSchoolId", newSchoolId)

        //    };

        //    await _userUpdateRepository.ExecuteNonQueryAsync("[dbo].[uspMoveUserToNewSchool]", parameters);

        //    user.SchoolId = newSchoolId;

        //    return user;
        //}

        //public async Task AddRangeAsync(ICollection<UserViewModel> usersViewModels)
        //{
        //    var users = new List<User>();

        //    foreach (var userViewModel in usersViewModels)
        //    {
        //        var user = _userViewModelFactory.For(userViewModel);

        //        users.Add(user);
        //    }

        //    await _userRepository.AddRangeAsync(users);
        //}


    }
}
