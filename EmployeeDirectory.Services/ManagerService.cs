using AutoMapper;
using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;

namespace EmployeeDirectory.Services
{
    public class ManagerService : IManagerService
    {
        readonly IManagerRepositary _managerHandler;
        readonly IMapper _mapper;

        public ManagerService(IManagerRepositary managerHandler,IMapper mapper)
        {
            this._managerHandler = managerHandler;
            this._mapper = mapper;
        }
        public List<Manager> GetManagers()
        {
            var managers = _mapper.Map<List<Data.Models.Manager>, List<Models.Manager>>(_managerHandler.GetManagers());
            return managers;
        }
        public string? GetManagerName(int id)
        {
            return _managerHandler.GetMangerNameById(id);
        }
    }
}
