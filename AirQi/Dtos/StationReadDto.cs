using AirQi.Models.Core;
using System;
using MongoDB.Bson;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Dtos
***REMOVED***
    public class StationReadDto 
    ***REMOVED***
        public string Id ***REMOVED*** get; set;***REMOVED***

        public string Location ***REMOVED*** get; set;***REMOVED***

        public string City ***REMOVED*** get; set;***REMOVED***

        public string Country ***REMOVED*** get; set;***REMOVED***

        public IEnumerable<Measurement> Measurements ***REMOVED*** get; set;***REMOVED***

        public Coordinates Coordinates ***REMOVED*** get; set;***REMOVED***

        public DateTime CreatedAt ***REMOVED*** get; set;***REMOVED***

        public DateTime UpdatedAt ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
***REMOVED***