using HermanosK.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HermanosK.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> GetServicesAsync();
        Task AddServiceAsync(Service service);
    }
}
