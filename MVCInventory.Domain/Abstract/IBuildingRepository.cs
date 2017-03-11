using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCInventory.Domain.Abstract
{
    public interface IBuildingRepository
    {
        //IEnumerable<Building> Buildings { get; }

        // repository pattern, keep a degree of separation between data model entities and the storage
        // and retrieval logic. 
        //without saying how and where the data is stored
        void Add(Building building);
        Building FetchByBuildingId(int Id);
        Building FetchByBuildingName(string Name);

        void SubmitChanges();

      
    }
    

}
