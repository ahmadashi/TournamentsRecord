using TR.Infrastructure.ViewModel;
using System.Collections.Generic;

namespace TR.Infrastructure.ViewModel
{
    public class TournamentUserViewModel : AuditedObjectViewModel
    {
        
        public int TournamentUserId { get; set; }


        
        public int TournamenttId { get; set; }

        
        public int UserId { get; set; }

        
        public string UserType { get; set; }

        
        public bool IsActive { get; set; }
              
               

    }
}
