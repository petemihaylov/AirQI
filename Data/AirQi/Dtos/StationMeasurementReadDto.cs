using AirQi.Models.Core;
using System;
using MongoDB.Bson;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Dtos
***REMOVED***
    public class StationMeasurementReadDto 
    ***REMOVED***
        public string Id ***REMOVED*** get; set;***REMOVED***

        public double  Aqi ***REMOVED*** get; set;***REMOVED***

        public IEnumerable<MeasurementReadDto> Measurements ***REMOVED*** get; set;***REMOVED***

        public double[] Position ***REMOVED*** get; set;***REMOVED***

        public DateTime CreatedAt ***REMOVED*** get; set;***REMOVED***

        public DateTime UpdatedAt ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
***REMOVED***