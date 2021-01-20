using System;
using AirQi.Models.Core;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Test.Repository
{
    public interface IMockDataRepository<TDocument> 
    {

        IEnumerable<TDocument> GetAll();

        Task<IEnumerable<TDocument>> GetAllAsync();

        IEnumerable<TDocument> GetAllLatest();

        Task<IEnumerable<TDocument>> GetAllLatestAsync();

        TDocument GetObjectByPosition(double[] position);

        Task<TDocument> GetObjectByPositionAsync(double[] position);
        
        void CreateObject(TDocument document);

        Task CreateObjectAsync(TDocument document);

        void UpdateObject(double[] position, TDocument document);

        Task UpdateObjectAsync(double[] position, TDocument document);

        void RemoveObject(TDocument document);

        Task RemoveObjectAsync(TDocument document);

        void RemoveObjectByPosition(double[] position);

        Task RemoveObjectByPositionAsync(double[] position);

    }
}