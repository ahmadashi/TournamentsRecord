using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TR.DAL.Models.Enums
{
    public enum SportType
    {
        [Display(Name = "Soccer")]
        Soccer,
        [Display(Name = "Tennis")]
        Tennis,
        [Display(Name = "Table Tennis")]
        TableTennis,
        [Display(Name = "Basketball")]
        Basketball,
    }
}
