using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TournamentsRecord.DAL.Models.Enums
{
    public enum SportType
    {
        [Display(Name = "Soccer")]
        Soccer,
        [Display(Name = "Table Tennis")]
        TableTennis,        
    }
}
