using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todoApiV1.services;

namespace todoApiV1.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public AuthController(IUserService userService,IAuthService authService ) 
        {
            _authService = authService;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Get(string email, string pw)
        {
            try{
                string result = _authService.GetAuthToken(email, pw);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest("INVALIED_EMAIL_OR_PASSWORD" + ex.Message);
            }
            
        }
    }
}
