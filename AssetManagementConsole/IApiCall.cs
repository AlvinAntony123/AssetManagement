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

        IQueryable<T> GetData();

        int PatchData(T data);
    }
}
