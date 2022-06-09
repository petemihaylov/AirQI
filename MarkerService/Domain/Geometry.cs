using System.Collections.Generic;

namespace MarkerService.Domain
{
    public class Geometry
    {
        public string Type { get; set; }
        public List<List<List<float>>> Coordinates { get; set; }

    }

}
