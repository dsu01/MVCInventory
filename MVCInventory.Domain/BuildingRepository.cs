using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCInventory.Domain.Abstract;

namespace MVCInventory.Domain
{
    public class BuildingRepository : IBuildingRepository 
    {

        public void Add(Building building)
        {

        }
        public Building FetchByBuildingId(int Id)
        {
            return new Building() { Id = Id };
        }

        public Building FetchByBuildingName(string Name)
        {
            return new Domain.Building() { BuildingName = Name };
        }

        public void SubmitChanges()
        {

        }
    }
}
