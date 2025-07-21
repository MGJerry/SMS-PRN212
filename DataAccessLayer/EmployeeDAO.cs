using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class EmployeeDAO
    {
        /*static List<Employee> employees = new List<Employee>();
        private bool isGenerated = false;
        public List<Employee> GenerateSampleDataset()
        {
            if (isGenerated)
            {
                return employees;
            }

            employees.Add(new Employee()
            {
                EmployeeId = 1,
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
                EmployeeId = 2,
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
                EmployeeId = 3,
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
                EmployeeId = 4,
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
                EmployeeId = 5,
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
        }*/

        /*public List<Employee> GetDataFromDatabase ()
        {
            return DatabaseContext.GetDbContext().Employees.ToList();
        }*/

        public static List<Employee> GetEmployees()
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool AddEmployee(Employee employee)
        {
            try
            {
                using var context = new LucySalesDataContext();
                context.Employees.Add(employee);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool RemoveEmployee(int employeeId)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var employee = context.Employees.Find(employeeId);

                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Employee SearchEmployee(int employeeId)
        {
            try
            {
                using var context = new LucySalesDataContext();
                return context.Employees
                    .Include(e => e.Orders)
                    .FirstOrDefault(e => e.EmployeeId == employeeId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Cap nhat thong tin nhan vien
        public static bool UpdateEmployee(Employee employee)
        {
            try
            {
                using var context = new LucySalesDataContext();
                var existingEmployee = context.Employees.Find(employee.EmployeeId);

                if (existingEmployee != null)
                {
                    existingEmployee.Name = employee.Name;
                    existingEmployee.UserName = employee.UserName;
                    existingEmployee.Password = employee.Password;
                    existingEmployee.JobTitle = employee.JobTitle;
                    existingEmployee.BirthDate = employee.BirthDate;
                    existingEmployee.HireDate = employee.HireDate;
                    existingEmployee.Address = employee.Address;

                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
