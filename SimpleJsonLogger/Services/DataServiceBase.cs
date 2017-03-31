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
            return _context.GetDocumentCollection<TDocument>().All().AsQueryable();
        }

        public TDocument Create(TDocument document)
        {
            return _context.GetDocumentCollection<TDocument>().Add(document);
        }

        public TDocument Find(string id)
        {
            return _context.GetDocumentCollection<TDocument>().Find(id);
        }

        public IQueryable<TDocument> Query(Expression<Func<TDocument, bool>> query)
        {
            return _context.GetDocumentCollection<TDocument>().Query(query);
        }

        public IQueryable<TDocument> Query(string query)
        {
            return _context.GetDocumentCollection<TDocument>().Query(query);
        }

        public void Remove(TDocument document)
        {
            _context.GetDocumentCollection<TDocument>().Remove(document);
        }

        public TDocument Update(TDocument document)
        {
            return _context.GetDocumentCollection<TDocument>().Update(document);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
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
