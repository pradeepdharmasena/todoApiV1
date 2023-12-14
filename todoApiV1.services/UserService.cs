using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todoApiV1.models;
using todoApiV1.repository;
using todoApiV1.services.dtos;

namespace todoApiV1.services
{

    public class UserService : IUserService
    {
        public readonly AppDbContext _userDbContext;
        public UserService() {
            _userDbContext = new AppDbContext();
        }


        public AppUser GetByCredentials(string email, string pw)
        {
            return _userDbContext.AppUsers.Where(user => user.Email.Equals(email) && user.Password.Equals(pw)).First();  
                
        }

        public AppUser GetByEmail(string email)
        {
            return _userDbContext.AppUsers.Where(user => user.Email.Equals(email)).First();

        }

        public AppUser Create(AppUserCreateDTO userRegisterReqDto)
        {
            AppUser user = new AppUser(); 
            user.Email = userRegisterReqDto.Email;
            user.FirstName = userRegisterReqDto.FirstName;
            user.LastName = userRegisterReqDto.LastName;
            user.Birthday = userRegisterReqDto.Birthday;
            user.Password = userRegisterReqDto.Password;

            _userDbContext.Add(user);
            _userDbContext.SaveChanges();
            return user;
        }

        public AppUser Update(AppUserCreateDTO userRegisterReqDto)
        {
            throw new NotImplementedException();
        }
    }

}
