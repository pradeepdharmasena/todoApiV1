using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todoApiV1.models;
using todoApiV1.services;
using todoApiV1.services.dtos;

namespace todoApiV1.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        public readonly IUserService _userService;
        public AppUserController(IUserService userService) 
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("email")]
        public IActionResult Get(string email)
        {
            return Ok(email);
        }

        [HttpPost]
        public IActionResult Create(UserRegisterReqDto userRegisterReqDto)
        {
           AppUser user =  _userService.Create(userRegisterReqDto);
           return Ok(user);
        }

        
    }
}
