using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace HermanosK.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _entities = new();
        private int _nextId = 1;

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.FromResult(_entities);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Task.FromResult(_entities.FirstOrDefault());
        }

        public async Task AddAsync(T entity)
        {
            _entities.Add(entity);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            await Task.CompletedTask;
        }
    }
}
