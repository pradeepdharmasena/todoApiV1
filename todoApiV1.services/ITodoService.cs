using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todoApiV1.models;
using todoApiV1.services.dtos;

namespace todoApiV1.services
{
    public interface ITodoService
    {
        public ToDo? Create(int userId, ToDoDto toDoDto);

        public List<ToDo> GetToDos(int userId);
    }
}
