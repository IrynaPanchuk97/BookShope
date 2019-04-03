using BookStory.Interface;
using BookStory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStory.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ShopeContext _dbContext;
        public BookRepository(ShopeContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public void Create(Book item)
        {
            _dbContext.Books.Add(item);
        }

        public void Delete(Book item)
        {
            _dbContext.Books.Remove(item);
        }

        public Book Find(int id)
        {
           return _dbContext.Books.Find(id);
        }
        public IEnumerable<Book> FindByName(string name)
        {
            return _dbContext.Books.Where(i => i.Title == name);
        }

        public async Task<IList<Book>> GetAllAsync()
        {
            return await _dbContext.Set<Book>().ToListAsync();
        }


        public IEnumerable<Book> GetAllBookWithAvtors()
        {
            return _dbContext.Books
                             .Include(i => i.BookAvtors)
                             .ThenInclude(j=>j.Avtor);
        }

        public IEnumerable<Book> GetAllBookWithUsers()
        {
            return _dbContext.Books
                              .Include(i => i.UserBooks)
                              .ThenInclude(j => j.User);
        }

        public void Update(Book item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
        public IEnumerable<Book> GetAllBookSomeUser(string login)
        {
            IEnumerable<UserBook> p = _dbContext.UserBooks.Where(i => i.User.Login.Equals(login));
            IEnumerable<int> b = p.Select(u => u.IdBook);
            List<Book> books = new List<Book>();
            foreach (var i in b)
            {
                books.Add(Find(i));
            }
            return books;
        }
    }
}
