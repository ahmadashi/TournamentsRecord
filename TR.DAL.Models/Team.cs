using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TR.DAL.Models
{
    public class Team :AuditedObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }

        [Required, ForeignKey("Tournament")]
        public int TournamenttId { get; set; }

        [Required, MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(25)]
        public string YearEstablish { get; set; }

        [Required, ForeignKey("SportType")]
        public int SportTypeId { get; set; }

        [ForeignKey("Logo")]
        public int LogId { get; set; }
        [ForeignKey("TeamId")]
        public virtual List<Staff> Staff { get; set; }
        [ForeignKey("TeamId")]
        public virtual List<Player> Players { get; set; }
        
        public virtual Logo Logo { get; set; }
    }
}
