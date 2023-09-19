using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Interfaces
{
    internal interface IBulkAdditionManager<T> where T : class
    {
        void AddBulk(List<T> objs, int number);
    }
}
