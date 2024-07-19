using EmployeeDirectory.Data.Models;

namespace EmployeeDirectory.Data.Contract
{
    public interface IRoleRepositary
    {
        void AddRole(Role role);
        List<Role> GetRoles();
        Role? GetRoleById(int roleId);
        int GetRoleCount();
        int GetRoleId(string roleName, int location, int department);
        void Update(int roleId, string fieldName, string fieldInputData);
        void Delete(int roleId);
    }
}