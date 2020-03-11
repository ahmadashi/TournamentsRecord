using TournamentsRecord.Infrastructure.ViewModel;
using System.Collections.Generic;

namespace TournamentsRecord.Infrastructure.ViewModel
{
    public class LogoViewModel : AuditedObjectViewModel
    {
        
        public int LogoId { get; set; }

        
        public string Url { get; set; }

        
        public bool IsActive { get; set; }

        
        public string Description { get; set; }

    }
}
