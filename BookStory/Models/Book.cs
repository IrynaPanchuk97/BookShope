using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStory.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public string TrendPictureURL { get; set; }

        [DataType(DataType.Url)]
        public string UrlDownload{ get; set; }
        public ICollection<UserBook> UserBooks { get; set; }
        public ICollection<BookAvtor> BookAvtors { get; set; }
    }
}
