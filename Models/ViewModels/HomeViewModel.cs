using System.Collections.Generic;
using HermanosK.Models;

namespace HermanosK.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Feature> Features { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }
}