using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogueApp.Data
{
    public interface IRepository<TEntity>
        where TEntity : class
        
    {
            IEnumerable<TEntity> All();
            void Add(TEntity entity);
            void Update(TEntity entity);
            void Delete(TEntity entity);
            int SaveChanges();
    }
    
}
