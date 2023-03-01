using SharedLiblary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MuradAuthServer.Core.Service
{
    public interface IGenericService<TEntity,TDto> where TEntity: class where TDto:class, new()
    {
        Task<Response<TDto>> GetByIdAsync(int id);
        Task<Response<IEnumerable<TDto>>> GetAllAsync();
        Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate);
        /*Where(x=>x.Id == 5) burada "x=>" olan hisse TEntity hissesine uygun gelir, "x.Id==5" olan hisse ise bool tipine uygun gelir ki, bu sorguda 5-e beraberdir ya yox ? sorgusu gedir
         * 
        Biz ne zaman ToList() desek o zaman sorgunu yerine yetirir*/
        Task<Response<TDto>> AddAsync(TDto dto);
        Task<Response<NoDataDto>> Remove(int id);
        Task<Response<NoDataDto>> Update(TDto dto, int id);
    }
}
