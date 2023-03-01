using Microsoft.EntityFrameworkCore;
using MuradAuthServer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MuradAuthServer.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {

            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return await _dbSet.AsNoTracking().ToListAsync();
        //
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity =  await _dbSet.FindAsync(id);
            if (entity == null) { _context.Entry(entity).State = EntityState.Detached; }
            /*Yoxlama edir eger bele bir ID movcud edeyilse Entity framework bu ID-ni izlemeyi dayandiri*/
            return entity; 
  
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            //_dbSet.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
            //Orderby basqa where sorgulari yazib en sonda tolist yazsam edecek
        }
    }
}
