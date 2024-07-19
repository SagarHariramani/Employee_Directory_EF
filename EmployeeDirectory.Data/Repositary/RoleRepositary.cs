using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Data.Models;

namespace EmployeeDirectory.Data.Repositary
{
    public class RoleRepositary : IRoleRepositary
    {
        public void AddRole(Models.Role role)
        {
            using (var context = new SagarEmployeeDirectoryDbContext())
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }
        public List<Models.Role> GetRoles()
        {
            using (var context = new SagarEmployeeDirectoryDbContext())
            {
                List<Models.Role> roles = context.Roles.ToList();
                return roles;
            }
        }
        public void Update(int roleId, string fieldName, string fieldInputData)
        {
            using (var context = new SagarEmployeeDirectoryDbContext())
            {
                Models.Role role = context.Roles.FirstOrDefault(e => e.Id == roleId)!;
                var propertyInfo = typeof(Models.Role).GetProperty(fieldName.ToString())!;
                propertyInfo.SetValue(role, fieldInputData);
                context.SaveChanges();
            }
        }
        public int GetRoleCount()
        {
            int count;
            using (var context = new SagarEmployeeDirectoryDbContext())
            {
                count = context.Roles.Count();
                return count;
            }
        }
        public Models.Role? GetRoleById(int? roleId)
        {
            Models.Role? roleDetail;
            using (var context = new SagarEmployeeDirectoryDbContext())
            {
                if (roleId == null)
                {
                    roleDetail = null;
                    return roleDetail;
                }
                else
                {
                    roleDetail = context.Roles.FirstOrDefault(r => r.Id == roleId);
                    return roleDetail;
                }
                
            }
        }
        public int? GetRoleId(string roleName, int location, int department)
        {
            int? roleId;
            using (var context = new SagarEmployeeDirectoryDbContext())
            {
                if (location == 0|| department == 0 || roleName== "")
                {
                    return null;
                }
                else
                {
                    roleId = context.Roles.FirstOrDefault(e => e.Name == roleName && e.LocationId == location && e.DepartmentId == department)!.Id;
                    return roleId;
                }
            }

        }
        public void Delete(int roleId)
        {
            using (var Context = new SagarEmployeeDirectoryDbContext())
            {
                Models.Role role = Context.Roles.FirstOrDefault(e => e.Id == roleId)!;
                Context.Roles.Remove(role);
                Context.SaveChanges();
            }
        }
    }

}
