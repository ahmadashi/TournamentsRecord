using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TournamentsRecord.DAL.Models
{
    public class Player :AuditedObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }

        [Required, ForeignKey("Team")]
        public int TeamId { get; set; }

        [Required, MaxLength(25)]
        public string FirstName { get; set; }

        [Required, MaxLength(25)]
        public string LastName { get; set; }

        [Required, MaxLength(25)]
        public string DOB { get; set; }

        [MaxLength(25)]
        public string POB { get; set; }

        [MaxLength(25)]        
        public string PhoneNumber { get; set; }

        [MaxLength(25)]
        public string Email { get; set; }

        [MaxLength(25)]
        public string Nationality { get; set; }

        [ForeignKey("Logo")]
        public int LogId { get; set; }

        public virtual Logo Logo { get; set; }

        public virtual Team Team { get; set; }

    }
}
