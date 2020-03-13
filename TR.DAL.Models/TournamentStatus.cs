using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TR.DAL.Models
{
    public class TournamentStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TournamentStatusId { get; set; }

        [Required, MaxLength(50)]
        public string Description { get; set; }

    }
}
