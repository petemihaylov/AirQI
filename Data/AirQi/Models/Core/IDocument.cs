using System;
using System.Collections.Generic;
using AirQi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Models.Core
***REMOVED***
    public interface IDocument
    ***REMOVED***
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        ObjectId Id ***REMOVED*** get; set;***REMOVED***

        DateTime CreatedAt ***REMOVED*** get; set;***REMOVED***

        DateTime UpdatedAt ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
***REMOVED***