using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Interfaces
{
    public interface IAllocationManager<T> where T : class
    {
        int Allocate(T obj);

        int Deallocate(T obj);
    }
}
