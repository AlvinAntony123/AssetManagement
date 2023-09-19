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
    public class EmployeeHandler
    {
        private readonly IEnitityManager<Employee> employeeManager;
        private readonly DepartmentHandler departmentHandler;
        public EmployeeHandler()
        {
            employeeManager = new EntityManager<Employee>("api/employee");
            departmentHandler = new DepartmentHandler();
        }

        public IQueryable<Employee> GetEmployeeList()
        {
            return employeeManager.Get();
        }
        public void AddEmployee()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--------------------Add Employee------------------");
                Console.WriteLine("Enter the employee details: ");
                Console.Write("Enter the name:");
                var empName = Console.ReadLine();
                departmentHandler.GetDepartments();
                Console.WriteLine("1.Do you want to add to existing deptartment\n2.Do you want to add new");
                Console.Write("Enter you option:");
                var op1 = Convert.ToInt32(Console.ReadLine());
                int deptId = 0;
                if(op1 == 1)
                {
                    Console.Write("Enter the deptartment id:");
                    deptId = Convert.ToInt32(Console.ReadLine());
                }
                else if(op1 == 2)
                {
                    deptId = departmentHandler.AddDepartment();
                }

                var emp = new Employee
                {
                    EmployeeName = empName,
                    DepartmentId = deptId,
                };
                var requestNo = employeeManager.Add(emp);
                if(requestNo == -1)
                {
                    Console.WriteLine("Error in adding employee");
                }else
                    Console.WriteLine("Your employee has been added successfully");
                Console.WriteLine("Do you want to continue (0/1)");
                var op = Convert.ToInt32(Console.ReadLine());
                if (op == 0) break;
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
