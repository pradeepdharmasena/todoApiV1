using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todoApiV1.models;

namespace todoApiV1.services.dtos
{
    public class MultimediaDto
    {
          
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public int ToDoId { get; set; }
    }
}
