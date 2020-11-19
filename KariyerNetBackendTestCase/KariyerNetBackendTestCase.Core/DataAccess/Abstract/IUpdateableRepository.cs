using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KariyerNetBackendTestCase.Core.Entity.Abstract;

namespace KariyerNetBackendTestCase.Core.DataAccess.Abstract
{
    public interface IUpdateableRepository<TEntity, TPrimaryKey>:ISaveableRepository
        where TEntity : class, IEntity<TPrimaryKey>, new()
        where TPrimaryKey : struct
    {
        /// <summary>
        /// Kayıt Update edilen method
        /// </summary>
        /// <param name="entity">Güncellenecek Kayıt</param>
        /// <param name="excludedColumns">Güncelleme yapılırken hariç tutulacak sütunlar</param>
        /// <returns></returns>
        TEntity Update(TEntity entity, params Expression<Func<TEntity, object>>[] excludedColumns);

        /// <summary>
        /// Kayıt Update edilen asenkron method
        /// </summary>
        /// <param name="entity">Güncellenecek Kayıt</param>
        /// <param name="excludedColumns">Güncelleme yapılırken hariç tutulacak sütunlar</param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] excludedColumns);

    }
}
