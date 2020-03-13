using TR.Infrastructure.ViewModel;
using System.Collections.Generic;

namespace TR.Infrastructure.ViewModel
{
    public class TeamViewModel : AuditedObjectViewModel
    {

        public int TeamId { get; set; }

        
        public int TournamenttId { get; set; }

        
        public string Name { get; set; }

        
        public string YearEstablish { get; set; }

        
        public int SportTypeId { get; set; }

        
        public int LogId { get; set; }
    }
}
