using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace ApiBase.Models
{
    public class FeatureCollection
    {
        public string Type { get; set; }

        public List<Feature> Features { get; set; }

    }

}
