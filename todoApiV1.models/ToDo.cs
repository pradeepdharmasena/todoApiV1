using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace todoApiV1.models
{
    public class ToDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Tittle { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public DateOnly DuedDate { get; set; } = new DateOnly();

        public DateOnly CreatedDate { get; set;} = new DateOnly();

        public DateOnly UpdatedDate { get; set;} = new DateOnly();

        public int UserId { get; set; }

        [JsonIgnore]
        public AppUser User { get; set; }

        public ICollection<Multimedia> Multimedias { get; set; } = new List<Multimedia>();
    }
}
