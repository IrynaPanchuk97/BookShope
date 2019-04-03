using BookStory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStory.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Avtor> Avtors  { get; }
        IUserRepository Users { get; }
        IBookRepository Books { get; }
        Task SaveChangesAsync();
    }
}
