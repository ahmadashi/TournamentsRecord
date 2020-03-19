using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TR.DAL.Models.Enums
{
    public enum TournamentType
    {
        [Display(Name = "Tournament (Playoff)")]
        Playoff,
        [Display(Name = "One Leg League")]
        OneLeg,
        [Display(Name = "Two Legs Leage")]
        TwoLeg
    }
}
