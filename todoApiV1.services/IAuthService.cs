using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todoApiV1.models;

namespace todoApiV1.services
{
    public interface IAuthService
    {
        public string GetAuthToken(string email, string pw);

        public string CreateToken(AppUser user);
    }
}
