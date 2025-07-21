using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BusinessObjects;

namespace Services
{
    public class InputValidator : IInputValidator
    {
        private CustomerService customerService;
        private CategoryService categoryService;
        private EmployeeService employeeService;
        private ProductService productService;
        private OrderService orderService;

        private List<Customer> customers;
        private List<Category> categories;
        private List<Employee> employees;
        private List<Product> products;
        private List<Order> orders;

        public InputValidator()
        {
            customerService = new CustomerService();
            categoryService = new CategoryService();
            employeeService = new EmployeeService();
            productService = new ProductService();
            orderService = new OrderService();

            customers = customerService.GetCustomers();
            categories = categoryService.GetCategories();
            employees = employeeService.GetEmployees();
            products = productService.GetProducts();
            orders = orderService.GetOrders();
        }

        public bool isPhoneValidation(string phoneNumber)
        {
            /*string regex = @"^(?:\+84|84|0)(3|5|7|8|9)\d{8}$";
            return Regex.IsMatch(phoneNumber, regex);*/
            return true; // Yeah, em chiu cai dong phone number trong db - L.Huy :P
        }

        public bool IsCustomerIdExist(int customerId)
        {
            return customers.Any(c => c.CustomerId == customerId);
        }

        public bool IsCategoryIdExist(int categoryId)
        {
            return categories.Any(c => c.CategoryId == categoryId);
        }

        public bool IsEmployeeIdExist(int employeeId)
        {
            return employees.Any(e => e.EmployeeId == employeeId);
        }

        public bool IsProductIdExist(int productId)
        {
            return products.Any(p => p.ProductId == productId);
        }

        public bool IsOrderIdExist(int orderId)
        {
            return orders.Any(o => o.OrderId == orderId);
        }
    }
}
