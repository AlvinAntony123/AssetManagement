using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole
{
    internal interface IApiCall<T> where T : class
    {
        int PostData(T data);

        int PostMany(int count, int facilityId, int currCount);

        IQueryable<T> GetData();

        int PatchData();
    }
}
