using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todoApiV1.models;

namespace todoApiV1.services.dtos
{
    public class ToDoDto
    {
        public string Tittle { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public DateOnly DuedDate { get; set; } = new DateOnly();

        public DateOnly CreatedDate { get; set; } = new DateOnly();

        public DateOnly UpdatedDate { get; set; } = new DateOnly();

        public ICollection<MultimediaDto> Multimedias { get; set; } = new List<MultimediaDto>();
    }
}
