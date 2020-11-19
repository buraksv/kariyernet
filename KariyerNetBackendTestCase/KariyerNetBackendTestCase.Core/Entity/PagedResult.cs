using System;
using System.Collections.Generic;

namespace KariyerNetBackendTestCase.Core.Entity
{
    public class PagedResult<T>
    {
        public PagedResult()
        {
            
        }
        public PagedResult(int currentPage, int pageSize, int rowCount)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            RowCount = rowCount; 
        }

        public int CurrentPage { get; }
        public int PageCount => (int)Math.Ceiling((double)RowCount / PageSize);
        public int PageSize { get; }
        public int RowCount { get; }
        public int FirstRowOnPage => (CurrentPage - 1) * PageSize + 1;
        public int LastRowOnPage => Math.Min(CurrentPage * PageSize, RowCount);
        public IEnumerable<T> List { get; set; }
    }
}
