using AssetManagementConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Managers
{
    public class EntityManager<T> : IEnitityManager<T> where T : class
    {
        private readonly IApiCall<T> apiObj1;

        public EntityManager(string ep)
        {
            apiObj1 = new ApiCall<T>(ep);
        }

        public int Add(T obj)
        {
            var id = apiObj1.PostData(obj);
            return id;
        }

        public IQueryable<T> Get()
        {
            var list = apiObj1.GetData();
            return list;
        }
    }
}
