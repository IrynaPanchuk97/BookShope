using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStory.Models
{
    public class BookAvtor
    {
        public int IdAvtor{ get; set; }
        public Avtor Avtor { get; set; }
        public int IdBook { get; set; }
        public Book Book { get; set; }
    }
}
