using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Interfaces
{
    internal interface IReportManager<T>
    {
        IQueryable<T> GenerateReport();
    }
}
