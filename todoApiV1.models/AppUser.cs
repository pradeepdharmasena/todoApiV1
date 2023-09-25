using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todoApiV1.models
{
    public class AppUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly Birthdate { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; } = string.Empty;
        public ICollection<ToDo> ToDos { get; } = new List<ToDo>();
    }
}
