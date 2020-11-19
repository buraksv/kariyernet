using System.Collections.Generic;
using System.Threading.Tasks;
using KariyerNetBackendTestCase.Core.Entity.Abstract;

namespace KariyerNetBackendTestCase.Core.DataAccess.Abstract
{
    public interface ITrashableRepository<TEntity, TPrimaryKey>:ISaveableRepository
        where TEntity : class, IEntity<TPrimaryKey>, new()
        where TPrimaryKey : struct
    {
        /// <summary>
        /// Kayıtları Id numarasına göre Geri Dönüşüm yapabilecek şekilde silen method
        /// </summary>
        /// <param name="id">Silinecek Kayıt Id'si</param>
        int MoveToTrash(TPrimaryKey id);
        /// <summary>
        /// Kayıtları Id numaralarına göre Geri Dönüşüm yapabilecek şekilde silen method
        /// </summary>
        /// <param name="id">Silinecek Kayıt Id'leri</param>
        int MoveToTrash(params TPrimaryKey[] id);
        /// <summary>
        /// Kayıtları Kayıt Objesine göre Geri Dönüşüm yapabilecek şekilde silen method
        /// </summary>
        /// <param name="entity">Silinecek Kayıt</param>
        int MoveToTrash(TEntity entity);
        /// <summary>
        /// Çoklu kayıt silinen method
        /// </summary>
        /// <param name="entities">Silinecek Kayıtlar</param>
        int MoveToTrash(IEnumerable<TEntity> entities);
        /// <summary>
        /// Kayıtları Id numarasına göre Geri Dönüşüm yapabilecek şekilde silen asenkron method
        /// </summary>
        /// <param name="id">Silinecek Kayıt Id si</param>
        Task<int> MoveToTrashAsync(TPrimaryKey id);
        /// <summary>
        /// Kayıtları Id numaralarıa göre Geri Dönüşüm yapabilecek şekilde silen asenkron method
        /// </summary>
        /// <param name="id">Silinecek Kayıt Id si</param>
        Task<int> MoveToTrashAsync(params TPrimaryKey[] id);
        /// <summary>
        /// Kayıtları Kayıt Objesine göre Geri Dönüşüm yapabilecek şekilde silen asenkron method
        /// </summary>
        /// <param name="entity">Silinecek Kayıt</param>
        Task<int> MoveToTrashAsync(TEntity entity);
        /// <summary>
        /// Çoklu kayıt silinen asenkron method
        /// </summary>
        /// <param name="entities">Silinecek Kayıtlar</param>
        Task<int> MoveToTrashAsync(IEnumerable<TEntity> entities);




        /// <summary>
        /// Kayıtları Id numarasına göre Geri Dönüşüm yapabilecek şekilde silen method
        /// </summary>
        /// <param name="id">Silinecek Kayıt Id'si</param>
        int RollBackFromTrash(TPrimaryKey id);
        /// <summary>
        /// Kayıtları Id numaralarına göre Geri Dönüşüm yapabilecek şekilde silen method
        /// </summary>
        /// <param name="id">Silinecek Kayıt Id'leri</param>
        int RollBackFromTrash(params TPrimaryKey[] id);
        /// <summary>
        /// Kayıtları Kayıt Objesine göre Geri Dönüşüm yapabilecek şekilde silen method
        /// </summary>
        /// <param name="entity">Silinecek Kayıt</param>
        int RollBackFromTrash(TEntity entity);
        /// <summary>
        /// Çoklu kayıt silinen method
        /// </summary>
        /// <param name="entities">Silinecek Kayıtlar</param>
        int RollBackFromTrash(IEnumerable<TEntity> entities);
        /// <summary>
        /// Kayıtları Id numarasına göre Geri Dönüşüm yapabilecek şekilde silen asenkron method
        /// </summary>
        /// <param name="id">Silinecek Kayıt Id si</param>
        Task<int> RollBackFromTrashAsync(TPrimaryKey id);
        /// <summary>
        /// Kayıtları Id numaralarıa göre Geri Dönüşüm yapabilecek şekilde silen asenkron method
        /// </summary>
        /// <param name="id">Silinecek Kayıt Id si</param>
        Task<int> RollBackFromTrashAsync(params TPrimaryKey[] id);
        /// <summary>
        /// Kayıtları Kayıt Objesine göre Geri Dönüşüm yapabilecek şekilde silen asenkron method
        /// </summary>
        /// <param name="entity">Silinecek Kayıt</param>
        Task<int> RollBackFromTrashAsync(TEntity entity);
        /// <summary>
        /// Çoklu kayıt silinen asenkron method
        /// </summary>
        /// <param name="entities">Silinecek Kayıtlar</param>
        Task<int> RollBackFromTrashAsync(IEnumerable<TEntity> entities);
    }
}
