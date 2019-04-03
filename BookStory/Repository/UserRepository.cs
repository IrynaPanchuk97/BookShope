using BookStory.Interface;
using BookStory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStory.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopeContext _dbContext;
        public UserRepository(ShopeContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public void AddBook(int bookid, int userid)
        {
            _dbContext.UserBooks.Add(new UserBook { IdBook = bookid, IdUser = userid });
        }

        public void Create(User item)
        {
            _dbContext.Users.Add(item);
        }

        public void Delete(string login)
        {
            _dbContext.Users.Remove(FindByLogin(login));
        }

        public void Delete(User item)
        {
            _dbContext.Users.Remove(item);
        }

        public void DeleteBook(int bookid, int userid)
        {
            _dbContext.UserBooks.Remove(new UserBook { IdUser = userid, IdBook = bookid });
        }

        public bool ExistBook(int idbook,int iduser)
        {
            List< UserBook> t = _dbContext.UserBooks.Where(u => u.IdBook==idbook).ToList();
            List<UserBook> m = t.Where(i => i.IdUser == iduser).ToList();
            if (m.Count>0) return false;
            return true;


        }

        public User Find(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public User FindByLogin(string login)
        {
           return _dbContext.Users.Where(i => i.Login.Equals(login)).ToList()[0];

        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await _dbContext.Set<User>().ToListAsync();
        }


        public IEnumerable<User> GetAllUserWithBooks()
        {
            return _dbContext.Users
                             .Include(i => i.UserBooks)
                             .ThenInclude(j => j.Book);
        }

        public void Update(User item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
