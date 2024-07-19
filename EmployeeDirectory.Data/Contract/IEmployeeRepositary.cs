using EmployeeDirectory.Models;

namespace EmployeeDirectory.Data.Contract
{
    public interface IEmployeeRepositary
    {
        void AddEmployee(Models.Employee employee);
        List<Models.Employee> GetEmployees();
        Models.Employee? GetEmployeeById(string empId);
        void Update<T>(string empId, Enum fieldName, T fieldInputData);
        void Delete(string empId);
    }
}