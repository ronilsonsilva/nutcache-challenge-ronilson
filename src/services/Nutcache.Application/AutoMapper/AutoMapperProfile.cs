using AutoMapper;
using Nutcache.Application.Models;

namespace Nutcache.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeDto, Domain.Entities.Employee>().ReverseMap();
            CreateMap<CreateEmployeeDto, Domain.Entities.Employee>().ReverseMap();
            CreateMap<UpdateEmployeeDto, Domain.Entities.Employee>().ReverseMap();
            CreateMap<ListEmployeeDto, Domain.Entities.Employee>().ReverseMap();
        }
    }
}
