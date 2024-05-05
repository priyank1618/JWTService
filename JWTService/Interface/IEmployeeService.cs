using JWTService.Models;

namespace JWTService.Interface
{
    public interface IEmployeeService
    {

        public List<Employee> GetEmployees();

        public Employee GetEmployee(int id);

        public Employee AddEmployee(Employee employee);

        public Employee UpdateEmployee(Employee employee);

        public void DeleteEmployee(int id);
    }
}
