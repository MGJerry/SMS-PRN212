using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataLayer;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public bool AddEmployee(Employee employee)
        {
            return EmployeeDAO.AddEmployee(employee);
        }

        public List<Employee> GenerateSampleDataset()
        {
            return EmployeeDAO.GetEmployees();
        }

        public List<Employee> GetEmployees()
        {
            return EmployeeDAO.GetEmployees();
        }

        public bool RemoveEmployee(int employeeId)
        {
            return EmployeeDAO.RemoveEmployee(employeeId);
        }

        public Employee SearchEmployee(int employeeId)
        {
            return EmployeeDAO.SearchEmployee(employeeId);
        }

        public bool UpdateEmployee(Employee employee)
        {
            return EmployeeDAO.UpdateEmployee(employee);
        }
    }
}
