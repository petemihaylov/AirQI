using Aqi.Models;
using System;
using MongoDB.Bson;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using Aqi.Models.Models;

namespace Aqi.Dtos
***REMOVED***
    public class StationReadDto 
    ***REMOVED***
        public string Id ***REMOVED*** get; set;***REMOVED***

        public string City ***REMOVED*** get; set;***REMOVED***
  
        public Country Country ***REMOVED*** get; set;***REMOVED***
      
        public Location Location ***REMOVED*** get; set;***REMOVED***
      
        public ICollection<Measurement> Measurements ***REMOVED*** get; set;***REMOVED***

        public DateTime CreatedAt ***REMOVED*** get; set;***REMOVED***

        public DateTime UpdatedAt ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
***REMOVED***