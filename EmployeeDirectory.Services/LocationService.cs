using AutoMapper;
using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;

namespace EmployeeDirectory.Services
{
    public class LocationService : ILocationService
    {
        readonly IMapper _mapper;
        readonly IGenericRepositary<Data.Models.Location> _genericRepositary;
        public LocationService(IMapper mapper, IGenericRepositary<Data.Models.Location> genericRepositary)
        {
            this._mapper = mapper;
            this._genericRepositary = genericRepositary;
        }
        public List<Location> GetLocations()
        {
            var locations = _mapper.Map<List<Data.Models.Location>, List<Models.Location>>(_genericRepositary.GetData());
            return locations;

        }
        public string? GetLocationName(int id)
        {
            return _genericRepositary.GetNameById(id);
        }
    }
}
