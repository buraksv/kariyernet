using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KariyerNetBackendTestCase.Core.Entity.Abstract;

namespace KariyerNetBackendTestCase.Core.DataAccess.Abstract
{
    public interface IQueryableRepository<TEntity, TPrimaryKey> : IDisposable
        where TEntity : class, IEntity<TPrimaryKey>, new()
        where TPrimaryKey : struct
    {
 
        /// <summary>
        /// Database arama sonuçlarının liste halinde alınacağı method
        /// </summary>
        /// <param name="filter">Filtre kriterlerinin girileceği parametre</param>
        /// <param name="orderBy">Sıralama kriterinin girileceği paramtre</param>
        /// <param name="select">Seçilen Sütunlar</param>
        /// <param name="topRecords">Çekilecek Kayıt sayısı</param>
        /// <returns></returns>
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? topRecords = null, params Expression<Func<TEntity, object>>[] includes);
        /// <summary>
        /// Database arama sonuçlarının liste halinde alınacağı method
        /// </summary>
        /// <param name="filter">Filtre kriterlerinin girileceği parametre</param>
        /// <param name="orderBy">Sıralama kriterinin girileceği paramtre</param>
        /// <param name="select">Seçilen Sütunlar</param>
        /// <param name="topRecords">Çekilecek Kayıt sayısı</param>
        /// <returns></returns>
        List<TResult> GetList<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? topRecords = null, params Expression<Func<TEntity, object>>[] includes) where TResult : class, new();

        /// <summary>
        /// Database arama sonuçlarının liste halinde alınacağı method
        /// </summary>
        /// <param name="filter">Filtre kriterlerinin girileceği parametre</param>
        /// <param name="orderBy">Sıralama kriterinin girileceği paramtre</param>
        /// <param name="select">Seçilen Sütunlar</param>
        /// <param name="topRecords">Çekilecek Kayıt sayısı</param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? topRecords = null, params Expression<Func<TEntity, object>>[] includes);
        /// <summary>
        /// Database arama sonuçlarının liste halinde alınacağı method
        /// </summary>
        /// <param name="filter">Filtre kriterlerinin girileceği parametre</param>
        /// <param name="orderBy">Sıralama kriterinin girileceği paramtre</param>
        /// <param name="select">Seçilen Sütunlar</param>
        /// <param name="topRecords">Çekilecek Kayıt sayısı</param>
        /// <returns></returns>
        Task<List<TResult>> GetListAsync<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? topRecords = null, params Expression<Func<TEntity, object>>[] includes) where TResult : class, new();

        /// <summary>
        /// Database arama sonuçlarının sorgusunun alınacağı method
        /// </summary>
        /// <param name="filter">Filtre kriterlerinin girileceği parametre</param>
        /// <param name="orderBy">Sıralama kriterinin girileceği paramtre</param>
        /// <param name="select">Seçilen Sütunlar</param>
        /// <param name="topRecords">Çekilecek Kayıt sayısı</param>
        /// <returns></returns>
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? topRecords = null, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Tekli kayıt çekilen method
        /// </summary>
        /// <param name="filter">Filtre Kriterleri</param>
        /// <returns></returns>
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter);
        /// <summary>
        /// Tekli kayıtta sadece belirli sütunları çeken method
        /// </summary>
        /// <param name="filter">Filtre Kriterleri</param>
        /// <param name="select">Seçilecek Sütunlar</param>
        /// <returns></returns>
        TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> select,Expression<Func<TEntity, bool>> filter) where TResult : class, new();
        /// <summary>
        /// ID parametresine göre kayıt getiren method
        /// </summary>
        /// <param name="id">Getirilecek Kaydın Id'si</param>
        /// <returns></returns>
        TEntity GetByIdFirstOrDefault(TPrimaryKey id);
        /// <summary>
        /// ID parametresine göre sadece belirli sütunları seçip kayıt getiren method
        /// </summary>
        /// <param name="id">Getirilecek Kaydın Id'si</param>
        /// <param name="select">Seçilecek Sütunlar</param>
        /// <returns></returns>
        TResult GetByIdFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> select, TPrimaryKey id) where TResult : class, new();
        /// <summary>
        /// ID parametrelerine göre kayıt getiren method
        /// </summary>
        /// <param name="id">Getirilecek kayıtların Id'leri</param>
        /// <returns></returns>
        List<TEntity> GetById(params TPrimaryKey[] id);
        /// <summary>
        /// ID parametrelerine göre  sadece belirli sütunları seçip  kayıt getiren method
        /// </summary>
        /// <param name="id">Getirilecek kayıtların Id'leri</param>
        /// <param name="select">Seçilecek Sütunlar</param>
        /// <returns></returns>
        List<TResult> GetById<TResult>(Expression<Func<TEntity, TResult>> select, params TPrimaryKey[] id) where TResult : class, new();
        /// <summary>
        /// Filtre kriterlerine göre kayıt olup olmadığının sonucunu veren method
        /// </summary>
        /// <param name="filter">Filtre Kriterleri</param>
        /// <returns></returns>
        bool Exists(Expression<Func<TEntity, bool>> filter = null);
        /// <summary>
        /// Filtre Kriterlerine Göre Kayıt Sayısını Veren Method
        /// </summary>
        /// <param name="filter">Filtre Kriterleri</param>
        /// <returns></returns>
        int RecordCount(Expression<Func<TEntity, bool>> filter = null);
        /// <summary>
        /// Tekli asenkron kayıt çekilen method
        /// </summary>
        /// <param name="filter">Filtre Kriterleri</param>
        /// <returns></returns>
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter);
        /// <summary>
        /// Tekli asenkron sadece belirli sütunlar ile beraber kayıt çeken method
        /// </summary>
        /// <param name="filter">Filtre Kriterleri</param>
        /// <param name="select">Seçilecek Sütunlar</param>
        /// <returns></returns>
        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> filter) where TResult : class, new();
        /// <summary>
        /// ID parametresine göre asenkron olarak kayıt getiren method
        /// </summary>
        /// <param name="id">Getirilecek Kaydın Id'si</param>
        /// <returns></returns>
        Task<TEntity> GetByIdFirstOrDefaultAsync(TPrimaryKey id);
        /// <summary>
        /// ID parametresine göre asenkron olarak sadece belirli sütunları çekerek kayıt getiren method
        /// </summary>
        /// <param name="id">Getirilecek Kaydın Id'si</param>
        /// <param name="select">Seçilecek Sütunlar</param>
        /// <returns></returns>
        Task<TResult> GetByIdFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> select, TPrimaryKey id) where TResult : class, new();
        /// <summary>
        /// ID parametrelerine göre asenkron olarak kayıt getiren method
        /// </summary>
        /// <param name="id">Getirilecek Kayıtların Id'leri</param>
        /// <returns></returns>
        Task<List<TEntity>> GetByIdAsync(params TPrimaryKey[] id);
        /// <summary>
        /// ID parametrelerine göre asenkron olarak belirli sütunları seçip kayıt getiren method
        /// </summary>
        /// <param name="id">Getirilecek Kayıtların Id'leri</param>
        /// <param name="select">Seçilecek Sütunlar</param>
        /// <returns></returns>
        Task<List<TResult>> GetByIdAsync<TResult>(Expression<Func<TEntity, TResult>> select, params TPrimaryKey[] id) where TResult : class, new();
        /// <summary>
        /// Filtre kriterlerine göre kayıt olup olmadığının sonucunu asenkron olarak veren method
        /// </summary>
        /// <param name="filter">Filtre Kriterleri</param>
        /// <returns></returns>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter = null);
        /// <summary>
        /// Filtre Kriterlerine Göre Kayıt Sayısını Asenkron Olarak Veren Method
        /// </summary>
        /// <param name="filter">Filtre Kriterleri</param>
        /// <returns></returns>
        Task<int> RecordCountAsync(Expression<Func<TEntity, bool>> filter = null);
         

    }
}
