using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace todoApiV1.models
{
    public class Multimedia
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }

        public int ToDoId { get; set; }

        [JsonIgnore]
        public ToDo ToDo { get; set; }
    }
}
