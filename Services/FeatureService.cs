using HermanosK.Models;
using HermanosK.Repositories;
using HermanosK.Factories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HermanosK.Services
{
    public class FeatureService : BaseService<Feature>, IFeatureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityFactory<Feature> _featureFactory;
        private bool _initialized = false;

        public FeatureService(IUnitOfWork unitOfWork, IEntityFactory<Feature> featureFactory)
        {
            _unitOfWork = unitOfWork;
            _featureFactory = featureFactory;
        }

        private async Task InitializeDefaultFeaturesAsync()
        {
            if (_initialized) return;

            var defaultFeatures = new List<Feature>
            {
                new Feature 
                { 
                    Title = "Miembros de excelencia", 
                    Description = "Nuestro empleados cuentan con el conocimiento para poder cubrir las necesidades de un cliente frente a la reserva que quiera realizar.",
                    IconClass = "fa-star"
                },
                new Feature 
                { 
                    Title = "Buena relación con los clientes", 
                    Description = "Nuestros empleados manejan un buen sistema de buen trato a nuestros clientes para que se sientan satisfechos con la atención que se les esta dando.",
                    IconClass = "fa-users"
                },
                new Feature 
                { 
                    Title = "Excelentes servicios y equipos", 
                    Description = "Contamos con servicios y espacios que hemos dedicado tiempo y esfuerzo para que sea una experiencia inolvidable para nuestros clientes.",
                    IconClass = "fa-check-circle"
                }
            };

            foreach (var feature in defaultFeatures)
            {
                await _unitOfWork.Features.AddAsync(feature);
            }
            await _unitOfWork.SaveChangesAsync();
            _initialized = true;
        }

        public async Task<IEnumerable<Feature>> GetFeaturesAsync()
        {
            await InitializeDefaultFeaturesAsync();
            var features = await _unitOfWork.Features.GetAllAsync();
            foreach (var feature in features)
            {
                Notify(feature);
            }
            return features;
        }

        public async Task AddFeatureAsync(Feature feature)
        {
            await _unitOfWork.Features.AddAsync(feature);
            await _unitOfWork.SaveChangesAsync();
            Notify(feature);
        }
    }
}
