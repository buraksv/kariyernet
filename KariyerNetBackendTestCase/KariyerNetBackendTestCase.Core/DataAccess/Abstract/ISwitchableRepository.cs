using System.Collections.Generic;
using System.Threading.Tasks;
using KariyerNetBackendTestCase.Core.Entity.Abstract;

namespace KariyerNetBackendTestCase.Core.DataAccess.Abstract
{
    public interface ISwitchableRepository<TEntity, TPrimaryKey>:ISaveableRepository
        where TEntity : class, IEntity<TPrimaryKey>, new()
        where TPrimaryKey : struct
    {
        /// <summary>
        /// Gönderilen Kayıt Id'ye göre kaydın Durumu Aktif ise Pasif, Pasif ise Aktif hale getiren method
        /// </summary>
        /// <param name="id">Güncellenecek Kayıt Id'si</param>
        /// <returns></returns>
        TEntity ToggleStatus(TPrimaryKey id);
        /// <summary>
        /// Gönderilen Kayıt Id'lere göre kaydın Durumu Aktif ise Pasif, Pasif ise Aktif hale getiren method
        /// </summary>
        /// <param name="id">Güncellenek Kayıtların Id'leri</param>
        /// <returns></returns>
        IEnumerable<TEntity> ToggleStatus(params TPrimaryKey[] id);
        /// <summary>
        /// Gönderilen Kayıt Objesine göre kaydın Durumu Aktif ise Pasif, Pasif ise Aktif hale getiren method
        /// </summary>
        /// <param name="entity">Güncellenecek Kayıt</param>
        /// <returns></returns>
        TEntity ToggleStatus(TEntity entity);
        /// <summary>
        /// Gönderilen Kayıt Id'ye göre kaydın Durumu Aktif ise Pasif, Pasif ise Aktif hale asenkron olarak getiren method
        /// </summary>
        /// <param name="id">Güncellenecek Kayıt Id'si</param>
        /// <returns></returns>
        Task<TEntity> ToggleStatusAsync(TPrimaryKey id);
        /// <summary>
        /// Gönderilen Kayıt Id'lerine göre kaydın Durumu Aktif ise Pasif, Pasif ise Aktif hale asenkron olarak getiren method
        /// </summary>
        /// <param name="id">Güncellenecek Kayıt Id'leri</param>
        /// <returns></returns>
        Task<List<TEntity>> ToggleStatusAsync(params TPrimaryKey[] id);
        /// <summary>
        /// Gönderilen Kayıt Objesine göre kaydın Durumu Aktif ise Pasif, Pasif ise Aktif hale asenkron getiren method
        /// </summary>
        /// <param name="entity">Güncellenecek Kayıt Id'si</param>
        /// <returns></returns>
        Task<TEntity> ToggleStatusAsync(TEntity entity);
    }
}
