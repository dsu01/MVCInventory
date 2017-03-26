using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCInventory.Domain;

namespace MVCInventory.Business.Abstract
{
    public interface IFacilityRepository
    {

        IEnumerable<Facility> GetAll();
        // repository pattern, keep a degree of separation between data model entities and the storage
        // and retrieval logic. 
        //without saying how and where the data is stored
        Facility Add(Facility item);
        Facility FetchByFacilityId(Guid id);
        Facility FetchByFacilityName(string Name);

        Facility Update(Facility building);
        void DeleteFacility(Guid id);
        int SubmitChanges();


    }
}
