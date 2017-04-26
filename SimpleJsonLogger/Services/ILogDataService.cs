using DocumentDbClient.Documents;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleJsonLogger.Services
{
    internal interface ILogDataService<TDocument> : IDisposable
    {
        IQueryable<TDocument> All();

        TDocument Create(TDocument document);

        TDocument Find(string id);

        IQueryable<TDocument> Query(Expression<Func<TDocument, bool>> query);

        IQueryable<TDocument> Query(string query);

        void Remove(TDocument document);

        TDocument Update(TDocument document);
    }
}