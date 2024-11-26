using HermanosK.Models;
using HermanosK.Repositories;
using HermanosK.Factories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HermanosK.Services
{
    public class ServiceService : BaseService<Service>, IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private bool _initialized = false;

        public ServiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private async Task InitializeDefaultServicesAsync()
        {
            if (_initialized) return;

            var defaultServices = new List<Service>
            {
                new Service 
                { 
                    Name = "Playa Blanca", 
                    Description = "",
                    ImageUrl = "/images/playa blanca.jpg"
                },
                new Service 
                { 
                    Name = "Guachalito", 
                    Description = "",
                    ImageUrl = "/images/guachalito.jpg"
                },
                new Service 
                { 
                    Name = "Morromico", 
                    Description = "",
                    ImageUrl = "/images/morromico.jpg"
                }
            };

            foreach (var service in defaultServices)
            {
                await _unitOfWork.Services.AddAsync(service);
            }
            await _unitOfWork.SaveChangesAsync();
            _initialized = true;
        }

        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            await InitializeDefaultServicesAsync();
            var services = await _unitOfWork.Services.GetAllAsync();
            foreach (var service in services)
            {
                Notify(service);
            }
            return services;
        }

        public async Task AddServiceAsync(Service service)
        {
            await _unitOfWork.Services.AddAsync(service);
            await _unitOfWork.SaveChangesAsync();
            Notify(service);
        }
    }
}
