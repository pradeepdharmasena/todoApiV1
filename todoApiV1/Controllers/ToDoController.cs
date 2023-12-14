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
            Console.WriteLine("--------------------------");
            Console.WriteLine("Id " + id);
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
        public IActionResult Create(ToDoCreateDto toDoDto) 
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
                
                return BadRequest(ex.Message);
            }
        }

        [Route("{toDoId}")]
        [HttpPut]
        public IActionResult Update(int toDoId, [FromBody] ToDoUpdateDto toDoDto)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Id " +  toDoId);
            Console.WriteLine("Title " + toDoDto.Tittle);
            try
            {
                Claim? claimAppUserId = User?.FindFirst("UserId");
                if (claimAppUserId == null)
                {
                    return NotFound("User not found");
                }
                ToDo? todo = _todoService.Update(toDoId, toDoDto);
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return BadRequest("Error occured." + ex.Message);
            }

        }
        [Route("{toDoId}")]
        [HttpDelete]
        public IActionResult Delete(int toDoId) 
        {
            try
            {
                Claim? claimAppUserId = User?.FindFirst("UserId");
                if (claimAppUserId == null)
                {
                    return NotFound("User not found");
                }
                Boolean isDeleted = _todoService.Delete(toDoId);
                if (isDeleted)
                {
                    return Ok("Deleted");
                }
                else
                {
                    return BadRequest("Unable to Delete");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest("Error occured.");
            }
        }
    }
}
