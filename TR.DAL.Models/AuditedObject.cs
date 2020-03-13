using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TR.DAL.Models
{
    public class AuditedObject
    {
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required, MaxLength(25)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime ModifyDate { get; set; }

        [Required, MaxLength(25)]
        public string ModifyBy { get; set; }
    }
}
