using EmployeeDirectory.Data.Models;

namespace EmployeeDirectory.Data.Contract
{
    public interface IManagerRepositary
    {
        List<Manager> GetManagers();
        string? GetMangerNameById(int id);
    }
}