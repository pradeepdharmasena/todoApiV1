using AutoMapper;
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
    public class ToDoService : ITodoService
    {

        private AppDbContext appDbContext;
        private IMapper mapper;
        public ToDoService(IMapper mapper)
        {

            this.appDbContext = new AppDbContext(); ;
            this.mapper = mapper;
        }

        public List<ToDo> GetToDos(int userId)
        {

            var user = appDbContext.AppUsers.SingleOrDefault(u => u.Id == userId);
            var todos = user?.ToDos.ToList();
            return todos;
        }

        public ToDo? Create(int userId, ToDoDto toDoDto)
        {
            AppUser user = appDbContext.AppUsers.SingleOrDefault(u => u.Id == userId);
            ToDo toDo = this.mapper.Map<ToDo>(toDoDto);

            user?.ToDos.Add(toDo);
            appDbContext.SaveChanges();
            return toDo;
        }

        public ToDo Delete(int toDoId)
        {
            ToDo todo = appDbContext.ToDo.First(todo => todo.Id == toDoId);
            appDbContext.ToDo.Remove(todo);
            appDbContext.SaveChanges();
            return todo;
        }

        public ToDo Update(int toDoId, ToDoDto toDoDto)
        {
            return null;
        }

    }

}