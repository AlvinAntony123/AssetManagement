using AssetManagementAPI.Models;
using AssetManagementConsole.Interfaces;
using AssetManagementConsole.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.FunctionHandlers
{
    public class DepartmentHandler
    {
        private readonly IEnitityManager<Department> deptManager;
        public DepartmentHandler()
        {
            deptManager = new EntityManager<Department>("api/department");
        }

        public void GetDepartments()
        {
            var deptList = deptManager.Get();
            if(deptList != null)
            {
                Console.WriteLine("Department List:");
                foreach (var dept in deptList)
                {
                    Console.WriteLine($"{dept.DepartmentId}. {dept.DepartmentName}");
                }
            }
        }

        public int AddDepartment()
        {
            Console.WriteLine("Enter the department name: ");
            var deptName = Console.ReadLine();

            var dept = new Department
            {
                DepartmentName = deptName,
            };
            var id = deptManager.Add(dept);
            if(id != -1)
            {
                Console.WriteLine("You deptartment has been added successfully");
                return id;
            }
            else
            {
                Console.WriteLine("Could not add department");
                return -1;
            }
        }
    }
}
