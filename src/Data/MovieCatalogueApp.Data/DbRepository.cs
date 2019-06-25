using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogueApp.Data
{
    public class DbRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class
     
    {
        private readonly MovieCatalogueAppContext _context;
        private DbSet<TEntity> dbSet;

        public DbRepository(MovieCatalogueAppContext context)
        {
            _context = context;
            this.dbSet = this._context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);

        }

        public IEnumerable<TEntity> All()
        {
            return this.dbSet;
        }

        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return this._context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
