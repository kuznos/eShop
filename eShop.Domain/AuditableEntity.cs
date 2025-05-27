using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain
{
    public class AuditableEntity
    {
        public string? CreatedBy { get; set; } = null;
        public DateTime? CreatedDate { get; set; } = null;
    }
}
