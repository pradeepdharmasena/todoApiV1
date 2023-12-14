using AutoMapper;
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
        public IMapper _mapper;
        public AppUserController(IUserService userService, IMapper mapper) 
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("email")]
        public IActionResult Get(string email)
        {
            try
            {
                AppUser appUser = _userService.GetByEmail(email);
                AppUserReadDTO response = _mapper.Map<AppUserReadDTO>(appUser);
                return Ok(response);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("emailFull")]
        public IActionResult GetFullUser(string email)
        {
            try
            {
                AppUser appUser = _userService.GetByEmail(email);
                return Ok(appUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Create(AppUserCreateDTO userRegisterReqDto)
        {
           AppUser user =  _userService.Create(userRegisterReqDto);
           AppUserReadDTO response = _mapper.Map<AppUserReadDTO>(user);
           return Ok(response);
        }

        
    }
}
