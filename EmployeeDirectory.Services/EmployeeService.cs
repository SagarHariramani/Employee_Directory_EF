using AutoMapper;
using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;

namespace EmployeeDirectory.Services
{

    public class EmployeeService : IEmployeeService
    {
        readonly IEmployeeRepositary _employeeHandler;
        readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepositary employeeHandler,IMapper mapper)
        {
            this._employeeHandler = employeeHandler;
            this._mapper = mapper;
        }

        public void AddEmployee(Employee emp)
        {
            var employee= _mapper.Map<Models.Employee,Data.Models.Employee>(emp);
            _employeeHandler.AddEmployee(employee);
        }
        public void EditEmployee <T>(string empId, Enum fieldName ,T fieldInputData)
        {
            _employeeHandler.Update(empId, fieldName, fieldInputData);
        }
        public void DeleteEmployee(string employeeId)
        {
            _employeeHandler.Delete(employeeId);
        }
        public Employee? GetEmployeeById(string empId)
        {
            var emp = _mapper.Map< Data.Models.Employee,Models.Employee>(_employeeHandler.GetEmployeeById(empId)!);
            return emp;
        }
        public List<Employee> GetEmployee()
        {
            var employee = _mapper.Map<List<Data.Models.Employee>, List<Models.Employee>>(_employeeHandler.GetEmployees());
            return employee ;
        }
    }
}
