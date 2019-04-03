using BookStory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStory.Interface
{
    public interface IUserRepository:IRepository<User>
    {
        User FindByLogin(string login);
        IEnumerable<User> GetAllUserWithBooks();
        void Delete(string login);
        void AddBook(int bookid, int userid);
        void DeleteBook(int bookid, int userid);
        bool ExistBook(int bookid, int userid);
    }
}