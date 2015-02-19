using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDataLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRep<T>() where T : class;
        void Save();
    }

    public class MusicUnitOfWork : IUnitOfWork
    {
        private MusicDbContext db = new MusicDbContext();
        private bool disposed = false;

        public IRepository<T> GetRep<T>() where T : class
        {
            var rep = new RepositoryUow<T>(db);
            return rep as IRepository<T>;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    db.Dispose(); // free the locked ressources
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // suppress calling the destructor
        }        
    }
}
