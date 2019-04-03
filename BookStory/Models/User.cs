using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStory.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }
        [Range(1, 150)]
        public int Age { get; set; }
        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }

    }
}
