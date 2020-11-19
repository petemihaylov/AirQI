using System;

namespace Aqi.Repository
***REMOVED***
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAttribute : Attribute
    ***REMOVED***
        public string CollectionName ***REMOVED*** get;***REMOVED***

        public BsonCollectionAttribute(string collectionName)
        ***REMOVED***
            CollectionName = collectionName;
       ***REMOVED***
   ***REMOVED***
***REMOVED***