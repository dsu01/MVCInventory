using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCInventory.Data;

namespace MyDataLayer
{
    public class MyContext : InventoryContext
    {
        public MyContext()
        {
            this.Configuration.LazyLoadingEnabled = false;

        }
    }
}
