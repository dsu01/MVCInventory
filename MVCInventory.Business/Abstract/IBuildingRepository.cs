using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCInventory.Domain;

namespace MVCInventory.Business.Abstract
{
    public interface IBuildingRepository
    {
      
        IEnumerable<Building> GetAll();
        // repository pattern, keep a degree of separation between data model entities and the storage
        // and retrieval logic. 
        //without saying how and where the data is stored
        Building Add(Building building);
        Building FetchByBuildingId(int Id);
        Building FetchByBuildingName(string Name);

        Building Update(Building building);
        void DeleteBuilding(int Id);
        int SubmitChanges();

      
    }
    

}
