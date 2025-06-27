using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer;

namespace DataLayer
{
    public class EmployeeDAO
    {
        static List<Employee> employees = new List<Employee>();
        private bool isGenerated = false;
        public List<Employee> GenerateSampleDataset()
        {
            if (isGenerated)
            {
                return employees;
            }

            employees.Add(new Employee()
            {
                EmployeeID = 1,
                Name = "Alice Nguyen",
                UserName = "alice.ng",
                Password = "Tech@123",
                JobTitle = "Software Engineer",
                BirthDate = new DateTime(1995, 5, 10),
                HireDate = new DateTime(2020, 1, 15),
                Address = "123 Tech Park, District 1"
            });

            employees.Add(new Employee()
            {
                EmployeeID = 2,
                Name = "Bob Tran",
                UserName = "bob.tr",
                Password = "Finance#456",
                JobTitle = "Senior Accountant",
                BirthDate = new DateTime(1988, 8, 22),
                HireDate = new DateTime(2015, 4, 5),
                Address = "45 Silicon Ave, District 3"
            });

            employees.Add(new Employee()
            {
                EmployeeID = 3,
                Name = "Charlie Le",
                UserName = "charlie.le",
                Password = "Dev$pass1",
                JobTitle = "Full Stack Developer",
                BirthDate = new DateTime(1992, 3, 18),
                HireDate = new DateTime(2018, 6, 20),
                Address = "12 Backend Blvd, District 5"
            });

            employees.Add(new Employee()
            {
                EmployeeID = 4,
                Name = "Diana Pham",
                UserName = "diana.ph",
                Password = "HRadmin!78",
                JobTitle = "HR Manager",
                BirthDate = new DateTime(1985, 11, 5),
                HireDate = new DateTime(2012, 9, 1),
                Address = "78 HR Plaza, District 10"
            });

            employees.Add(new Employee()
            {
                EmployeeID = 5,
                Name = "Ethan Doan",
                UserName = "ethan.do",
                Password = "Notes@987",
                JobTitle = "Executive Assistant",
                BirthDate = new DateTime(1990, 2, 28),
                HireDate = new DateTime(2019, 2, 10),
                Address = "89 Admin Street, Binh Thanh"
            });

            isGenerated = true;
            return employees;
        }

        /*public List<Employee> GetDataFromDatabase ()
        {
            return DatabaseContext.GetDbContext().Employees.ToList();
        }*/

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public bool AddEmployee(Employee employee)
        {
            Employee e = employees.FirstOrDefault(emp => emp.EmployeeID == employee.EmployeeID);
            if (e != null)
            {
                return false;
            }

            employees.Add(employee);
            return true;
        }
        public bool RemoveEmployee(int employeeId)
        {
            Employee e = employees.FirstOrDefault(emp => emp.EmployeeID == employeeId);
            if (e == null)
            {
                return false;
            }

            employees.Remove(e);
            return true;
        }

        public Employee SearchEmployee(int employeeId)
        {
            return employees.FirstOrDefault(emp => emp.EmployeeID == employeeId);
        }

        // Cap nhat thong tin nhan vien
        public bool UpdateEmployee(Employee employee)
        {
            Employee e = employees.FirstOrDefault(emp => emp.EmployeeID == employee.EmployeeID);
            if (e == null)
            {
                return false;
            }

            e.Name = employee.Name;
            e.UserName = employee.UserName;
            e.Password = employee.Password;
            e.JobTitle = employee.JobTitle;
            e.BirthDate = employee.BirthDate;
            e.HireDate = employee.HireDate;
            e.Address = employee.Address;

            return true;
        }
    }
}
