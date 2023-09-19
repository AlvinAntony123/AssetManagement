﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Interfaces
{
    public interface IEnitityManager<T> where T : class
    {
        int Add(T obj);

        int AddMany(int count, int facilityId, int currCount);

        IQueryable<T> Get();
    }
}
