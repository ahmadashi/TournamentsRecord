using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TR.DAL.Models.Enums
{
    public enum TournamentType
    {
        [Display(Name = "One Legies Leage")]
        OneLeg,
        [Display(Name = "Two Legies Leage")]
        TwoLeg,
        [Display(Name = "Tournament (Playoff)")]
        Playoff,
            
    }
}
