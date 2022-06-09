using System;

namespace MarkerService.Domain
{
    public class Feature
    {
        public string Type { get; set; }
        public Object properties { get; set; }
        public Geometry geometry { get; set; }

    }

}