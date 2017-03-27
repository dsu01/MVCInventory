using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCInventory.Business.Models
{
    public class FacilityModel
    {
        public System.Guid Id { get; set; }

        public string FacilityName { get; set; }

        public string FacilityGroup { get; set; }

        public int BuildingId { get; set; }
        public List<FacilityAttachmentModel> FacilityAttachments { get; set; }

        public BuildingModel Building { get; set; }
    }
}
