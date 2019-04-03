using BookStory.Interface;
using BookStory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStory.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ShopeContext _context;
        public UnitOfWork(ShopeContext context)
        {
            _context = context;
        }


        private bool disposed = false;

        public IRepository<Avtor> Avtors => new AvtorRepository(_context);

        public IUserRepository Users => new UserRepository(_context);

        public IBookRepository Books => new BookRepository(_context);


        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }

    }
}
