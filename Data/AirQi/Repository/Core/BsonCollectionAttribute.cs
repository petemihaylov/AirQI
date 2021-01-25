using System;

namespace AirQi.Repository.Core
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAttribute : Attribute
    {
        private string _collectionName;
        public string CollectionName { get => this._collectionName; set => this._collectionName = value; }

        public BsonCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}