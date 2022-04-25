using System.ComponentModel.DataAnnotations;
using System;

namespace ApiBase.Models
{
    public class Feature
    {
        public string Type { get; set; }
        public Object properties { get; set; }
        public Geometry geometry { get; set; }

    }

}