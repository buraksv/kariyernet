using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KariyerNetBackendTestCase.Core.Entity.Abstract;

namespace KariyerNetBackendTestCase.Core.DataAccess.Abstract
{
    public interface IDeleteableRepository<TEntity,TPrimaryKey>:ISaveableRepository
    where TEntity:class,IEntity<TPrimaryKey>,new()
    where TPrimaryKey:struct
    {
        /// <summary>
        /// Sorguya göre kayıt silmeye yarayan method
        /// </summary>
        /// <param name="filter">Silinecek Kayıtların Filtre Kriterleri</param>
        /// <returns></returns>
        int Delete(Expression<Func<TEntity, bool>> filter);
        /// <summary>
        /// Kayıt gönderilerek silmeye yarayan method
        /// </summary>
        /// <param name="entity">Silinecek Kayıt</param>
        int Delete(TEntity entity);
        /// <summary>
        /// Kayıt Id gönderilerek kayıt silmeye yarayan method
        /// </summary>
        /// <param name="id">Silinecek Kaydın Id Numarası</param>
        int Delete(TPrimaryKey id);
        /// <summary>
        /// Kayıt Id'leri gönderilerek kayıt silmeye yarayan method
        /// </summary>
        /// <param name="id">Silinecek Kayıtların Id Numaraları</param>
        int Delete(params TPrimaryKey[] id);
        /// <summary>
        /// Çoklu kayıt silinen method
        /// </summary>
        /// <param name="entities">Silinecek Kayıtlar</param>
        int Delete(IEnumerable<TEntity> entities);
        /// <summary>
        /// Sorguya göre asenkron kayıt silmeye yarayan method
        /// </summary>
        /// <param name="filter">Siilinecek Kayıtların Filtre Kriterleri</param>
        /// <returns></returns>
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> filter);
        /// <summary>
        /// Kayıt gönderilerek asenkron kayıt silmeye yarayan method
        /// </summary>
        /// <param name="entity"></param>
        Task<int> DeleteAsync(TEntity entity);
        /// <summary>
        /// Kayıt Id gönderilerek asenkron kayıt silmeye yarayan method
        /// </summary>
        /// <param name="id">Silinecek Kayıt Id'si</param>
        Task<int> DeleteAsync(TPrimaryKey id);
        /// <summary>
        /// Kayıt Id'lerine gönderilerek asenkron kayıt silmeye yarayan method
        /// </summary>
        /// <param name="id">Silinecek Kayıtların Id'leri</param>
        Task<int> DeleteAsync(params TPrimaryKey[] id);
        /// <summary>
        /// Çoklu kayıtlar asenkron silinen method
        /// </summary>
        /// <param name="entities">Silinecek Kayıtlar</param>
        Task<int> DeleteAsync(IEnumerable<TEntity> entities);

    }
}
