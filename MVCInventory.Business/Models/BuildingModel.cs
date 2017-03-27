using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCInventory.Business.Models
{
    public class BuildingModel
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public string Property { get; set; }

        public bool IsActive { get; set; }
    }
}
