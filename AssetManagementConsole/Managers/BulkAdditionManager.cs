using AssetManagementConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Managers
{
    internal class BulkAdditionManager<T> : IBulkAdditionManager<T> where T : class
    {
        private string endpoint;
        public BulkAdditionManager(string ep)
        {
            endpoint = ep;
        }
        public void AddBulk(List<T> objs, int number)
        {
            var finalEndpoint = $"{endpoint}/bulkadd?number={number}";
            IApiCall<T> apiObj = new ApiCall<T>(finalEndpoint);

        }
    }
}
