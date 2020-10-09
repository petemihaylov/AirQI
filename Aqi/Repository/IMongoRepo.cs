using Aqi.Models;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace Aqi.Repository
{
    public interface IMongoRepo<TDocument> where TDocument : IDocument
    {
        IEnumerable<TDocument> GetAll();

        Task<IEnumerable<TDocument>> GetAllAsync();
        
        TDocument GetObjectById(string id);

        Task<TDocument> GetObjectByIdAsync(string id);

        void CreateObject(TDocument document);

        Task CreateObjectAsync(TDocument document);

        void UpdateObject(string id, TDocument document);

        Task UpdateObjectAsync(string id, TDocument document);

        void RemoveObject(TDocument document);

        Task RemoveObjectAsync(TDocument document);

        void RemoveObjectById(string id);

        Task RemoveObjectByIdAsync(string id);

        IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression);

        IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<TDocument, bool>> filterExpression,Expression<Func<TDocument, TProjected>> projectionExpression);

        TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression);

        Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);
    }
}