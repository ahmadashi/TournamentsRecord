using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TournamentsRecord.DAL.Models.Enums
{
    public enum RoleType
    {
        [Display(Name = "Head Of Coaches")]
        HeadOfCoaches,
        [Display(Name = "Coach")]
        Coach,
        [Display(Name = "Coach Assestance")]
        CoachAssestance,
        [Display(Name = "Team Manager")]
        TeamManager,
        [Display(Name = "Fitness Trainer")]
        FitnessTrainer,        
    }
}
