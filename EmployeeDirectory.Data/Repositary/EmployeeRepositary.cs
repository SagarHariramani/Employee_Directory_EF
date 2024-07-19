using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Data.Models;

namespace EmployeeDirectory.Data.Repositary
{
    public class EmployeeRepositary : IEmployeeRepositary
    {
        public void AddEmployee(Employee employee)
        {
            using (var context = new SagarEmployeeDirectoryDbContext())
            {
                employee.CreatedOn = DateTime.UtcNow;
                employee.CreatedBy = "System";
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }
        public List<Employee> GetEmployees()
        {
            using (var context = new SagarEmployeeDirectoryDbContext())
            {
                List<Employee> employees = context.Employees.Where(e => e.IsDeleted != true).ToList();
                return employees;
            }
        }

        public Employee? GetEmployeeById(string empId)
        {
            using (var context = new SagarEmployeeDirectoryDbContext())
            {
                Employee? emp = context.Employees.FirstOrDefault(e => e.EmpId == empId && !e.IsDeleted);
                return emp;
            }
        }
        public void Update<T>(string empId, Enum fieldName, T fieldInputData)
        {
            using (var context = new SagarEmployeeDirectoryDbContext())
            {
                Employee emp = context.Employees.FirstOrDefault(e => e.EmpId == empId && !e.IsDeleted)!;
                var propertyInfo = typeof(Employee).GetProperty(fieldName.ToString())!;
                propertyInfo.SetValue(emp, fieldInputData);
                emp.UpdatedOn = DateTime.UtcNow;
                emp.UpdatedBy = "System";
                context.SaveChanges();
            }
        }
        public void Delete(string empId)
        {
            using (var context = new SagarEmployeeDirectoryDbContext())
            {
                Employee emp = context.Employees.FirstOrDefault(e => e.EmpId == empId && !e.IsDeleted)!;
                emp.IsDeleted = true;
                context.SaveChanges();
            }
        }
    }
}

