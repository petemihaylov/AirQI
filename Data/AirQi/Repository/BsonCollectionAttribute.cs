using System;

namespace AirQi.Repository
***REMOVED***
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAttribute : Attribute
    ***REMOVED***
        private string _collectionName;
        public string CollectionName ***REMOVED*** get => this._collectionName; set => this._collectionName = value;***REMOVED***

        public BsonCollectionAttribute(string collectionName)
        ***REMOVED***
            CollectionName = collectionName;
       ***REMOVED***
   ***REMOVED***
***REMOVED***