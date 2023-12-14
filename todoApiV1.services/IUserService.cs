using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todoApiV1.models;
using todoApiV1.services.dtos;

namespace todoApiV1.services
{
    public interface IUserService
    {
        public AppUser GetByCredentials(string email, string pw);
        public AppUser GetByEmail(string email);

        public AppUser Create(AppUserCreateDTO userRegisterReqDto);

        public AppUser Update(AppUserCreateDTO userRegisterReqDto);

    }
}
