using TR.Infrastructure.ViewModel;
using System.Collections.Generic;

namespace TR.Infrastructure.ViewModel
{
    public class TournamentViewModel : AuditedObjectViewModel
    {
        
        public int TournamentId { get; set; }

        
        public string Name { get; set; }

        
        public string SportType { get; set; }

        
        public string TournamentType { get; set; }

        
        public string StartDate { get; set; }

        
        public int LogId { get; set; }

    }
}
