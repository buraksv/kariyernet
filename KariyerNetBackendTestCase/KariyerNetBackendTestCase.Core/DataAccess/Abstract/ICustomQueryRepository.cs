using System.Collections.Generic;
using System.Threading.Tasks;
using KariyerNetBackendTestCase.Core.Entity.Abstract;

namespace KariyerNetBackendTestCase.Core.DataAccess.Abstract
{
    public interface ICustomQueryRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>, new()
        where TPrimaryKey : struct
    {
        /// <summary>
        /// Custom Sorgu çalıştırmak için bu method kullanılır
        /// </summary>
        /// <param name="customQuery">Çalıştırılacak Sorgu</param>
        /// <param name="commandTimeOut">Sorgunun çalıştırılacağı maximum Timeout Süresi</param>
        /// <returns></returns>
        IEnumerable<TEntity> ExecuteQuery(object customQuery,int commandTimeOut=30);
        /// <summary>
        /// Custom Sorgu çalıştırmak için asenkron olarak bu method kullanılır
        /// </summary>
        /// <param name="customQuery">Çalıştırılacak Sorgu</param>
        /// <param name="commandTimeOut">Sorgunun çalıştırılacağı maximum Timeout Süresi</param>
        /// <returns></returns>
        Task<List<TEntity>> ExecuteQueryAsync(object customQuery, int commandTimeOut = 30);
        /// <summary>
        /// Dönüş tipi belirsiz olan sorguları çalıştırmak için bu method kullanılır
        /// </summary>
        /// <param name="customQuery">Çalıştırılacak Sorgu</param>
        /// <param name="commandTimeOut">Sorgunun çalıştırılacağı maximum Timeout Süresi</param>
        /// <returns></returns>
        object ExecuteSpecialQuery(object customQuery,int commandTimeOut=30);
 
        /// <summary>
        /// Tek satır kayıt döndürecek olan sorguları çalıştırmak için bu method kullanılır
        /// </summary>
        /// <param name="customQuery">Çalıştırılacak Sorgu</param>
        /// <param name="commandTimeOut">Sorgunun çalıştırılacağı maximum Timeout Süresi</param>
        /// <returns></returns>
        TEntity ExecuteQueryFirstRow(object customQuery,int commandTimeOut=30);
        /// <summary>
        /// Tek satır kayıt döndürecek olan sorguları çalıştırmak için asenkron olarak bu method kullanılır
        /// </summary>
        /// <param name="customQuery">Çalıştırılacak Sorgu</param>
        /// <param name="commandTimeOut">Sorgunun çalıştırılacağı maximum Timeout Süresi</param>
        /// <returns></returns>
        Task<TEntity> ExecuteQueryFirstRowAsync(object customQuery, int commandTimeOut = 30);
        /// <summary>
        /// Sadece rakamsal veri döndürecek sorgular için bu method kullanılır
        /// </summary>
        /// <param name="customQuery">Çalıştırılacak Sorgu</param>
        /// <param name="commandTimeOut">Sorgunun çalıştırılacağı maximum Timeout Süresi</param>
        /// <returns></returns>
        int ExecuteQueryGetValue(object customQuery, int commandTimeOut = 30);
        /// <summary>
        /// Sadece rakamsal veri döndürecek sorgular için asenkron olarak bu method kullanılır
        /// </summary>
        /// <param name="customQuery">Çalıştırılacak Sorgu</param>
        /// <param name="commandTimeOut">Sorgunun çalıştırılacağı maximum Timeout Süresi</param>
        /// <returns></returns>
        Task<int> ExecuteQueryGetValueAsync(object customQuery, int commandTimeOut = 30);
        /// <summary>
        /// Herhangi bir dönüş dipi beklenmeyen sorgular için bu method kullanılır
        /// </summary>
        /// <param name="customQuery">Çalıştırılacak Sorgu</param>
        /// <param name="commandTimeOut">Sorgunun çalıştırılacağı maximum Timeout Süresi</param>
        void ExecuteQueryVoid(object customQuery, int commandTimeOut = 30);
        /// <summary>
        /// Herhangi bir dönüş dipi beklenmeyen sorgular için asenkron olarak bu method kullanılır
        /// </summary>
        /// <param name="customQuery">Çalıştırılacak Sorgu</param>
        /// <param name="commandTimeOut">Sorgunun çalıştırılacağı maximum Timeout Süresi</param>
        Task ExecuteQueryVoidAsync(object customQuery, int commandTimeOut = 30);
    }
}
