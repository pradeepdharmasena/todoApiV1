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
    public class UserProfiles : Profile
    {
        public UserProfiles() 
        {
            CreateMap<AppUser, UserRegisterReqDto>();
            CreateMap<UserRegisterReqDto, AppUser>();
        }
    }
}
