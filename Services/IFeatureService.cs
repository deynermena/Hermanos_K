using HermanosK.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HermanosK.Services
{
    public interface IFeatureService
    {
        Task<IEnumerable<Feature>> GetFeaturesAsync();
        Task AddFeatureAsync(Feature feature);
    }
}
