using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TournamentsRecord.DAL.Models.Enums
{
    public enum TournamentStatus
    {
        [Display(Name = "Registered : not started yet")]
        Registered,
        [Display(Name = "In-progress")]
        Inprogress,
        [Display(Name = "Suspended")]
        Suspended,
        [Display(Name = "Finished")]
        Finished,
            
    }
}
