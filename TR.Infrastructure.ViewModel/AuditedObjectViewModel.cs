using System;

namespace TR.Infrastructure.ViewModel
{
    public abstract class AuditedObjectViewModel
    {
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifyDate { get; set; }

        public string ModifyBy { get; set; }
    }
}
