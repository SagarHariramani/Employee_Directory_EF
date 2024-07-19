using AutoMapper;
using EmployeeDirectory.Data;
using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;

namespace EmployeeDirectory.Services
{
    public class ProjectService : IProjectService
    {
        readonly IMapper _mapper;
        readonly IGenericRepositary<Data.Models.Project> _genericRepositary;
        public ProjectService(IMapper mapper, IGenericRepositary<Data.Models.Project> genericRepositary)
        {
            this._mapper = mapper;
            this._genericRepositary = genericRepositary;
        }
        public List<Project> GetProjects()
        {
            var projects = _mapper.Map<List<Data.Models.Project>, List<Models.Project>>(_genericRepositary.GetData());
            return projects;
        }
        public string? GetProjectName(int? id)
        {
            return _genericRepositary.GetNameById(id);
        }
    }
}
