using AutoMapper;
using My_workeplae.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_workeplae.Helpers
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<Employees, EmployeesforList>()
                .ForMember(dest => dest.Manager_FirstName, opt =>
                opt.MapFrom(src => src.Manager.FirstName)).
                ForMember( dest=>dest.ManagerID,opt=>
                opt.MapFrom(src=>src.ManagerID));

            CreateMap<EmployeesforUpdateDto, Employees>();
               
             
        }
    }
}
