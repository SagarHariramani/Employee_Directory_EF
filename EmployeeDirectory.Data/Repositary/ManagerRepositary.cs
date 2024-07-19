using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Data.Models;
using Microsoft.Data.SqlClient;

namespace EmployeeDirectory.Data.Repositary
{
    public class ManagerRepositary : IManagerRepositary
    {
        public List<Models.Manager> GetManagers()
        {
            using (var context = new SagarEmployeeDirectoryDbContext())
            {
                List<Models.Manager> managers = context.Managers.ToList();
                return managers;
            }
        }

        public string? GetMangerNameById(int id)
        {
            string? mangerName;
            using (var context = new SagarEmployeeDirectoryDbContext())
            {
                mangerName = context.Managers.Where(m => m.Id == id)
                    .Select(m => m.Employee.FirstName + " " + m.Employee.LastName)
                    .FirstOrDefault();
                return mangerName;
            }
        }
    }
}
