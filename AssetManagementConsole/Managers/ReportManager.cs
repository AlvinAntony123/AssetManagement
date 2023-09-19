using AssetManagementConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Managers
{
    internal class ReportManager<T> : IReportManager<T> where T : class
    {
        private readonly IApiCall<T> apiObj;

        public ReportManager(string ep)
        {
            apiObj = new ApiCall<T>(ep);
        }
        public IQueryable<T> GenerateReport()
        {
            return apiObj.GetData();
        }
    }
}
