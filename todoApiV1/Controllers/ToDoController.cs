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

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetTodo(int id)
        {
            try
            {
                Claim? claimEmail = User?.FindFirst(ClaimTypes.Email);
                Claim? claimAppUserId = User?.FindFirst("UserId");
                if(claimAppUserId == null)
                {
                    return NotFound("User not found.");
                }
                ToDo? toDo = _todoService.GetToDo(int.Parse(claimAppUserId.Value), id);
                var ResponseObject = new { todo = toDo };
                return Ok(ResponseObject);

            }
            catch (Exception ex)
            {
                return BadRequest("Error occured.");
            }


        }
        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                Claim? claimEmail = User?.FindFirst(ClaimTypes.Email);
                Claim? claimAppUserId = User?.FindFirst("UserId");
                if(claimAppUserId == null)
                {
                    return NotFound("User not found.");
                }
                List<ToDo>? toDos = _todoService.GetToDos(int.Parse(claimAppUserId.Value));
                var ResponseObject = new { todos = toDos };
                return Ok(ResponseObject);

            }
            catch (Exception ex)
            {
                return BadRequest("Error occured.");
            }

            
        }

        [HttpPost]
        public IActionResult Create(ToDoDto toDoDto) 
        {
            try
            {
                Claim? claimAppUserId = User?.FindFirst("UserId");
                if (claimAppUserId == null)
                {
                    return NotFound("User not found");
                }
                ToDo? todo = _todoService.Create(int.Parse(claimAppUserId.Value), toDoDto);
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return BadRequest("Error occured.");
            }
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
