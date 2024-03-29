﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TR.DAL.Models
{
    public class TournamentUser : AuditedObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TournamentUserId { get; set; }


        [Required, ForeignKey("Tournament")]
        public int TournamentId { get; set; }

        [Required, ForeignKey("UserId")]
        public int UserId { get; set; }

        [Required]
        public UserType UserType { get; set; }

        [Required]
        public bool IsActive { get; set; }
        
        public virtual Tournament Tournament { get; set; }
        
        public virtual User User { get; set; }
    }
}
