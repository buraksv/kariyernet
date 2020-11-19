using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KariyerNetBackendTestCase.Core.Entity;
using KariyerNetBackendTestCase.Core.Entity.Abstract;

namespace KariyerNetBackendTestCase.Core.DataAccess.Abstract
{
    public interface IPageableRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>, new()
        where TPrimaryKey : struct
    {
        /// <summary>
        /// Sayfalamalı şekilde arama sonuçlarını getiren method
        /// </summary>
        /// <param name="filter">Filtre kriterleri</param>
        /// <param name="orderBy">Sıralama kriterleri</param>
        /// <param name="select">Seçilecek özel sütunlar</param>
        /// <param name="page">Görünecek olan sayfa</param>
        /// <param name="pageSize">Sayfa başı kayıt sayısı</param>
        /// <returns></returns>
        PagedResult<TEntity> GetPagedList(int page = 1, int? pageSize=null,Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Sayfalamalı şekilde arama sonuçlarını asenkron getiren method
        /// </summary>
        /// <param name="filter">Filtre kriterleri</param>
        /// <param name="orderBy">Sıralama kriterleri</param>
        /// <param name="select">Seçilecek özel sütunlar</param>
        /// <param name="page">Görünecek olan sayfa</param>
        /// <param name="pageSize">Sayfa başı kayıt sayısı</param>
        /// <returns></returns>
        Task<PagedResult<TEntity>> GetPagedListAsync(int page = 1, int? pageSize=null, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Sayfalamalı şekilde arama sonuçlarını istenen class tipine göre getiren method
        /// </summary>
        /// <param name="filter">Filtre kriterleri</param>
        /// <param name="orderBy">Sıralama kriterleri</param>
        /// <param name="select">Seçilecek özel sütunlar</param>
        /// <param name="page">Görünecek olan sayfa</param>
        /// <param name="pageSize">Sayfa başı kayıt sayısı</param>
        /// <returns></returns>
        PagedResult<TResult> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> select,int page = 1, int? pageSize = null, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null) where  TResult:class,new();

        /// <summary>
        /// Sayfalamalı şekilde arama sonuçlarını istenen class tipine göre asenkron getiren method
        /// </summary>
        /// <param name="filter">Filtre kriterleri</param>
        /// <param name="orderBy">Sıralama kriterleri</param>
        /// <param name="select">Seçilecek özel sütunlar</param>
        /// <param name="page">Görünecek olan sayfa</param>
        /// <param name="pageSize">Sayfa başı kayıt sayısı</param>
        /// <returns></returns>
        Task<PagedResult<TResult>> GetPagedListAsync<TResult>(Expression<Func<TEntity, TResult>> select,int page = 1, int? pageSize = null, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

    }
}
