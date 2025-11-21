using Microsoft.EntityFrameworkCore;   
using CMCS4.Data.Interfaces;

//Nikolov, G. (2018) Generic Repository Pattern in C# with EF Core. Packt Publishing.

namespace CMCS4.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CMCS4DbContext _ctx;

        public GenericRepository(CMCS4DbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<T>> GetAllAsync() =>
            await _ctx.Set<T>().ToListAsync();

        public async Task<T?> GetAsync(int id) =>
            await _ctx.Set<T>().FindAsync(id);

        public async Task<T> AddAsync(T entity)
        {
            await _ctx.Set<T>().AddAsync(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _ctx.Set<T>().Update(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity != null)
            {
                _ctx.Set<T>().Remove(entity);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
