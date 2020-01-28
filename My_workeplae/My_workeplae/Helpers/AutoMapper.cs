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
            CreateMap<EmployeesforUpdateDto, Employees>();
        }
    }
}
