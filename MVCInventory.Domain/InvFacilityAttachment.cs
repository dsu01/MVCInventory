using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCInventory.Domain
{
    public class FacilityAttachment
    {
        public System.Guid Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public System.DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsActive { get; set; }
        public string Title { get; set; }
       
        public System.Guid FacilityId { get; set; }

        public virtual Facility Facility { get; set; }
    }
}
