using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCInventory.Domain
{
    public class Facility
    {
        public Facility()
        {
            this.FacilityAttachments = new HashSet<FacilityAttachment>();
        }

        public System.Guid Id { get; set; }

        public string FacilityName { get; set; }

        public string FacilityGroup { get; set; }

        public int BuildingId { get; set; }

        public virtual ICollection<FacilityAttachment> FacilityAttachments { get; set; }

        public virtual Building Building { get; set; }
    }
}
