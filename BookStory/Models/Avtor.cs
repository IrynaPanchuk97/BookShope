using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStory.Models
{
    public class Avtor
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Avtor is required")]
        public string NameAvtor { get; set; }
        public ICollection<BookAvtor> BookAvtors { get; set; }

    }
}
