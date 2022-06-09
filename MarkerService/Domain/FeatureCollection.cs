using System.Collections.Generic;

namespace MarkerService.Domain
{
    public class FeatureCollection
    {
        public string Type { get; set; }

        public List<Feature> Features { get; set; }

    }

}
