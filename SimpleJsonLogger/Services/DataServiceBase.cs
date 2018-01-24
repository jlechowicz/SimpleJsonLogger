using DocumentDbClient.Context;
using DocumentDbClient.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJsonLogger.Services
{
    public abstract class DataServiceBase<TDocument> : IDisposable where TDocument : DocumentBase, new()
    {
        protected IDocumentDbContext _context;

        public DataServiceBase(IDocumentDbContext context)
        {
            _context = context;
        }

        public IQueryable<TDocument> All()
        {
            return _context.GetDocumentCollection().All<TDocument>().AsQueryable();
        }

        public TDocument Create(TDocument document)
        {
            return _context.GetDocumentCollection().Add<TDocument>(document);
        }

        public TDocument Find(string id)
        {
            return _context.GetDocumentCollection().Find<TDocument>(id);
        }

        public IQueryable<TDocument> Query(Expression<Func<TDocument, bool>> query)
        {
            return _context.GetDocumentCollection().Query<TDocument>(query);
        }

        public IQueryable<TDocument> Query(string query)
        {
            return _context.GetDocumentCollection().Query<TDocument>(query);
        }

        public void Remove(TDocument document)
        {
            _context.GetDocumentCollection().Remove(document);
        }

        public TDocument Update(TDocument document)
        {
            return _context.GetDocumentCollection().Update(document);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
