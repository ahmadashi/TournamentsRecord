using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentsRecord.DAL.Models
{
    public class User : AuditedObject
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required, MaxLength(128)]
        public string UserName { get; set; }


        [Required, MaxLength(64)]
        public string Password { get; set; }

        [Required, MaxLength(25)]
        public string FirstName { get; set; }

        [Required, MaxLength(25)]
        public string LastName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public UserType UserType { get; set; }
                
        [MaxLength(25)]
        public string PhoneNumber { get; set; }

        [MaxLength(25)]
        public string Email { get; set; }
       
        [ForeignKey("UserId")]
        public virtual List<TournamentUser> UserTournaments { get; set; }

        [ForeignKey("Logo")]
        public int LogId { get; set; }

        public virtual Logo Logo { get; set; }
    }
}
