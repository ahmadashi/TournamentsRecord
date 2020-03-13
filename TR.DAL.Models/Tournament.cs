using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TR.DAL.Models
{
    public class Tournament : AuditedObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TournamentId { get; set; }

        [Required, MaxLength(25)]
        public string Name { get; set; }

        [Required]
        public SportType SportType { get; set; }

        [Required]
        public TournamentStatus TournamentStatus { get; set; }

        [Required]
        public TournamentType TournamentType { get; set; }

        [MaxLength(25)]
        public string StartDate { get; set; }

        [ForeignKey("Logo")]
        public int LogId { get; set; }
        [ForeignKey("TournamentId")]
        public virtual List<Team> Teams { get; set; }
        [ForeignKey("TournamentId")]
        public virtual List<TournamentUser> TournamentUsers { get; set; }
        public virtual Logo Logo { get; set; }
    }
}
