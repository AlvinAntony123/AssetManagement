using AssetManagementConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Managers
{
    internal class AllocationManager<T> : IAllocationManager<T> where T : class
    {
        string endPoint;
        public AllocationManager(string ep)
        {
            endPoint = ep;
        }
        public int Allocate(int assetId, int empId)
        {
            var newEndpoint = endPoint + $"/{assetId}?empId={empId}";
            IApiCall<T> newObj = new ApiCall<T>(newEndpoint);
            return newObj.PatchData();
        }
    }
}
