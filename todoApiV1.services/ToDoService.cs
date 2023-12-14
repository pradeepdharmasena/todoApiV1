using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public List<ToDo>? GetToDos(int userId)
        {

            var user = appDbContext.AppUsers
                .Include(u => u.ToDos)
                .SingleOrDefault(u => u.Id ==userId );
            var todos = user?.ToDos.ToList();
            return todos;
        }

        public ToDo? GetToDo(int userId, int todoId)
        {

            var user = appDbContext.AppUsers
                .Include(u => u.ToDos)
                .SingleOrDefault(u => u.Id == userId);
            if (user != null)
            {
                ToDo? todo = user.ToDos.FirstOrDefault(t => t.Id == todoId);
                return todo;
            }

            return null;
        }

        public ToDo? Create(int userId, ToDoCreateDto toDoDto)
        {
            AppUser? user = appDbContext.AppUsers.SingleOrDefault(u => u.Id == userId);
            ToDo toDo = this.mapper.Map<ToDo>(toDoDto);

            user?.ToDos.Add(toDo);
            appDbContext.SaveChanges();
            return toDo;
        }

        public Boolean Delete(int toDoId)
        {
            try
            {
                ToDo todo = appDbContext.ToDo.First(todo => todo.Id == toDoId);
                appDbContext.ToDo.Remove(todo);
                appDbContext.SaveChanges();
                return true;
            }catch (Exception ex) {
                return false;
            }
            
        }

        public ToDo Update(int toDoId, ToDoUpdateDto toDoDto)
        {
            ToDo todo = appDbContext.ToDo.First(todo => todo.Id == toDoId);
            if(toDoDto.Tittle != null)
            {
                todo.Tittle = toDoDto.Tittle;
            }
            if(toDoDto.Description != null) {
                todo.Description = toDoDto.Description;
            }
            if (toDoDto.Status != null)
            {
                todo.Status = (int)toDoDto.Status;
            }
            if (toDoDto.DuedDate != null)
            {
                todo.DuedDate = (DateOnly)toDoDto.DuedDate;
            }
            if (toDoDto.Multimedias != null)
            {
                todo.Multimedias = (ICollection<Multimedia>)toDoDto.Multimedias;
            }

            appDbContext.SaveChanges();
            return todo;
        }

    }

}