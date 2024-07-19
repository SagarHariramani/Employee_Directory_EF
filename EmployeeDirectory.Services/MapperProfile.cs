﻿using AutoMapper;
using EmployeeDirectory.Data.Models;
using EmployeeDirectory.Services.Contract;

namespace EmployeeDirectory.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile() { 
            CreateMap<Employee,Models.Employee>().ReverseMap();
            CreateMap<Role,Models.Role>().ReverseMap();
            CreateMap<Department,Models.Department>().ReverseMap();
            CreateMap<Location,Models.Location>().ReverseMap();
            CreateMap<Manager,Models.Manager>().ReverseMap();
            CreateMap<Project,Models.Project>().ReverseMap();
        }

    }
}
