using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TR.DAL.Models
{
    public class Logo : AuditedObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogoId { get; set; }

        [MaxLength(512)]
        public string Url { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [MaxLength(64)]
        public string Description { get; set; }
    }
}
