using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TournamentsRecord.DAL.Models
{
    public class TournamentType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TournamentTypeId { get; set; }

        [Required, MaxLength(50)]
        public string Description { get; set; }

    }
}
