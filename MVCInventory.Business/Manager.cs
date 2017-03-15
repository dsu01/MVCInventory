using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCInventory.Business
{
   // public abstract class Manager<TM, TE> : IManager<TM, TE>
   public abstract class Manager<TM, TE> 
    {
        public virtual List<TM> Get()
        {
          //  var records = this.Store.GetAll();
           // return Mapper.Map<IEnumerable<TE>, List<TM>>(records);
            return null;
        }

    }

    public interface IManager<TM, TE>
    {
        int Id { get; set; }
        bool IsNew { get; }

        List<TM> Get();
        List<TM> Get(Func<TM, bool> predicate);
        //List<TM> GetFiltered(Expression<Func<TE, bool>> predicate);
        //List<TM> GetFiltered(params Expression<Func<TE, bool>>[] predicates);
        TM GetById(int id);

        void Delete(int id);
        void Delete(int id, bool forceDelete);
        TM Save(TM model);
      
    }
}
