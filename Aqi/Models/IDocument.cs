using System;
using Aqi.Models.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Models
***REMOVED***
    public interface IDocument
    ***REMOVED***
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        ObjectId Id ***REMOVED*** get; set;***REMOVED***

        DateTime CreatedAt ***REMOVED*** get; set;***REMOVED***

        DateTime UpdatedAt ***REMOVED*** get; set;***REMOVED***
        public Location Location ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
***REMOVED***