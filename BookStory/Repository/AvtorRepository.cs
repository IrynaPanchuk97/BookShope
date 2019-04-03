using BookStory.Interface;
using BookStory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStory.Repository
{
    public class AvtorRepository : IRepository<Avtor>
    {
        private readonly ShopeContext _dbContext;
        public AvtorRepository(ShopeContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public void Create(Avtor item)
        {
            _dbContext.Avtors.Add(item);
        }

        public void Delete(Avtor item)
        {
            _dbContext.Avtors.Remove(item);
        }

        public Avtor Find(int id)
        {
            return _dbContext.Avtors.Find(id);
        }

        public async Task<IList<Avtor>> GetAllAsync()
        {
            return await _dbContext.Set<Avtor>().ToListAsync();
        }

        public void Update(Avtor item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
