using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todoApiV1.models;
using todoApiV1.services.dtos;

namespace todoApiV1.services.profiles
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile() 
        {
            CreateMap<ToDo, ToDoDto>();
            CreateMap<ToDoDto, ToDo>()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore());
        }
    }
}
