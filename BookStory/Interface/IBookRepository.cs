using BookStory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStory.Interface
{
    public interface IBookRepository:IRepository<Book>
    {
        IEnumerable<Book> FindByName(string name);
        IEnumerable<Book> GetAllBookWithUsers();
        IEnumerable<Book> GetAllBookWithAvtors();
        IEnumerable<Book> GetAllBookSomeUser(string login);

    }
}
