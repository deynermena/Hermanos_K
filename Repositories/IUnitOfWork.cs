using System.Threading.Tasks;

namespace HermanosK.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Models.Feature> Features { get; }
        IRepository<Models.Service> Services { get; }
        Task<int> SaveChangesAsync();
    }
}
