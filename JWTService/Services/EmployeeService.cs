using JWTService.DataContext;
using JWTService.Interface;
using JWTService.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JWTService.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext applicationDbContext)
        {
                _context = applicationDbContext;
        }

        public Employee AddEmployee(Employee employee)
        {
           var emp =  _context.Employees.Add(employee);
            _context.SaveChanges();
            return emp.Entity;
        }

        public void DeleteEmployee(int id)
        {

            try
            {
                var employee = _context.Employees.FirstOrDefault(s => s.Id == id);

                if (employee == null)
                {
                    throw new Exception("User Not Found");
                }

                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            
            
        }

        public Employee GetEmployee(int id)
        {
            //first get that employee and return it
            var employee = _context.Employees.FirstOrDefault(s => s.Id == id);

            if (employee == null)
            {
                throw new Exception("User Not Found");
            }

            return employee;
        }

        public List<Employee> GetEmployees()
        {
            //we can get list of employee from db

            List<Employee> employees = _context.Employees.ToList();
            return employees;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var employees=_context.Update(employee);
            _context.SaveChanges();
            return employees.Entity;
        }

      
    }
}
