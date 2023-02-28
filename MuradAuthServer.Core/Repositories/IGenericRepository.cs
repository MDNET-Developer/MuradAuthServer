using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MuradAuthServer.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        /*Where(x=>x.Id == 5) burada "x=>" olan hisse TEntity hissesine uygun gelir, "x.Id==5" olan hisse ise bool tipine uygun gelir ki, bu sorguda 5-e beraberdir ya yox ? sorgusu gedir
         * 
        Biz ne zaman ToList() desek o zaman sorgunu yerine yetirir*/
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
