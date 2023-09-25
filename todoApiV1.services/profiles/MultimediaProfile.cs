using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todoApiV1.models;
using todoApiV1.services.dtos;

namespace todoApiV1.services.profiles
{
    public class MultimediaProfile : Profile
    {
        public MultimediaProfile() {
        
            CreateMap<Multimedia, MultimediaDto>();

            CreateMap<MultimediaDto, Multimedia>();
              // .ForMember(dest => dest.ToDo, opt => opt.Ignore())
              // .ForMember(dest => dest.ToDoId, opt => opt.Ignore());
        }
    }
}
