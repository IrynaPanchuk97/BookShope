using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStory.Models
{
    public class UserBook
    {
        public int IdUser { get; set; }
        public User User { get; set; }
        public int IdBook { get; set; }
        public Book Book { get; set; }
    }
}
