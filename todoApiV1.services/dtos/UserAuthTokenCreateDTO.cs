using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todoApiV1.services.dtos
{
    public class UserAuthTokenCreateDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
