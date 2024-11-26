using HermanosK.Models;

namespace HermanosK.Factories
{
    public class FeatureFactory : IEntityFactory<Feature>
    {
        public Feature Create()
        {
            return new Feature
            {
                Title = "Nuevo Feature",
                Description = "Descripción por defecto",
                IconClass = "fa-star"
            };
        }
    }
}
