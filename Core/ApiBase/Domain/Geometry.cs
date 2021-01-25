using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace ApiBase.Models
{
    public class Geometry
    {
        public string Type { get; set; }
        public List<List<List<float>>> Coordinates { get; set; }

    }

}
