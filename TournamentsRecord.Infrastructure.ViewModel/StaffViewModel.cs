using TournamentsRecord.Infrastructure.ViewModel;
using System.Collections.Generic;

namespace TournamentsRecord.Infrastructure.ViewModel
{
    public class StaffViewModel : AuditedObjectViewModel
    {
        
        public int StaffId { get; set; }

        
        public int TeamId { get; set; }

        
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
        public string DOB { get; set; }

        
        public string POB { get; set; }

        
        public string PhoneNumber { get; set; }

        
        public string Email { get; set; }

        
        public string Nationality { get; set; }

    }
}
