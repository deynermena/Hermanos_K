using System.Threading.Tasks;
using HermanosK.Models;

namespace HermanosK.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository<Feature> _features;
        private readonly IRepository<Service> _services;

        public UnitOfWork()
        {
            _features = new Repository<Feature>();
            _services = new Repository<Service>();
        }

        public IRepository<Feature> Features => _features;
        public IRepository<Service> Services => _services;

        public async Task<int> SaveChangesAsync()
        {
            return await Task.FromResult(1);
        }
    }
}
