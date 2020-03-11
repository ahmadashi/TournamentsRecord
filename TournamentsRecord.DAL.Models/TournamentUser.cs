using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentsRecord.DAL.Models
{
    public class TournamentUser : AuditedObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TournamentUserId { get; set; }


        [Required, ForeignKey("Tournament")]
        public int TournamentId { get; set; }

        [Required, ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public UserType UserType { get; set; }

        [Required]
        public bool IsActive { get; set; }
        
        public virtual Tournament Tournament { get; set; }
        
        public virtual List<User> Users { get; set; }
    }
}
