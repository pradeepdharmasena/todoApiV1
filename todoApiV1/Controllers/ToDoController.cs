using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using todoApiV1.models;
using todoApiV1.services;
using todoApiV1.services.dtos;

namespace todoApiV1.Controllers
{
    [Route("api/todo")]
    [ApiController]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private IConfiguration _configuration;
        private ITodoService _todoService;
        public ToDoController(IConfiguration configuration, ITodoService todoService)
        {
            _todoService = todoService;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Get()
        {
            Claim? claimEmail = User?.FindFirst(ClaimTypes.Email);
            Claim? claimAppUserId = User?.FindFirst("UserId"); 

            return Ok( claimAppUserId?.Value + " has request his tasks : " + claimEmail?.Value );
        }

        [HttpPost]
        public IActionResult Create(ToDoDto toDoDto) 
        {
            Claim? claimAppUserId = User?.FindFirst("UserId");
           ToDo todo = _todoService.Create(int.Parse(claimAppUserId?.Value), toDoDto);
            return Ok(todo);
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok("Not Implemnted");
        }

        [HttpDelete]
        public IActionResult Delete() 
        {
            return Ok("Not Implemnted");
        }
    }
}
