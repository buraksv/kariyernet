using System.Collections.Generic;
using System.Threading.Tasks;
using KariyerNetBackendTestCase.Core.Entity.Abstract;

namespace KariyerNetBackendTestCase.Core.DataAccess.Abstract
{
    public interface IInsertableRepository<TEntity, TPrimaryKey>:ISaveableRepository
        where TEntity : class, IEntity<TPrimaryKey>, new()
        where TPrimaryKey : struct
    {
        /// <summary>
        /// Anlık olarak kayıt ekleyip Primary Key değerini geri döndüren method
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TPrimaryKey InsertAndGetId(TEntity entity);
        /// <summary>
        /// Tekli kayıt eklenen method
        /// </summary>
        /// <param name="entity">Eklenecek Kayıt</param>
        /// <returns></returns>
        TEntity Add(TEntity entity);
        /// <summary>
        /// Çoklu kayıt eklenen method
        /// </summary>
        /// <param name="entities">Eklenecek Kayıtlar</param>
        void Add(IEnumerable<TEntity> entities);
        /// <summary>
        /// Asenkron tekli kayıt eklenen method
        /// </summary>
        /// <param name="entity">Eklenecek Kayıt</param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity entity);
        /// <summary>
        /// Asenkron çoklu kayıt eklenen method
        /// </summary>
        /// <param name="entities">Eklenecek Kayıtlar</param>
        Task AddAsync(IEnumerable<TEntity> entities);
        /// <summary>
        /// Anlık olarak kayıt ekleyip Primary Key değerini asenkron olarak geri döndüren method
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);
    }
}
