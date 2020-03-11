using TournamentsRecord.Infrastructure.ViewModel;
using System.Collections.Generic;

namespace TournamentsRecord.Infrastructure.ViewModel
{
    public class UserViewModel : AuditedObjectViewModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }       
        public string UserType { get; set; }

        public string UserTypeName { get; set; }

        public bool IsActive { get; set; }

        //public List<TournamentUser> UserTournaments { get; set; }


    }
}
