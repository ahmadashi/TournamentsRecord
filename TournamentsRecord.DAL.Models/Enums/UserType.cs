using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TournamentsRecord.DAL.Models.Enums
{
    public enum UserType
    {
        [Display(Name = "Tournament Admin")]
        Admin,
        [Display(Name = "Tournament User")]
        User,        
    }
}
