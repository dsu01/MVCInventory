using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCInventory.Domain.Interface
{
    //The Generic Interface Repository for Performing Read/Add/Delete operations
    public interface IBuildingRepository<TEnt, in TPk> where TEnt : class
    {
        //TEnt is set with the constraints as class.
        IEnumerable<TEnt> Get();
        TEnt Get(TPk id);
        void Add(TEnt entity);
        void Remove(TEnt entity);
    }
}
