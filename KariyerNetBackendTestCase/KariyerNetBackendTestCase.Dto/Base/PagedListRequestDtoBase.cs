using KariyerNetBackendTestCase.Core.Entity.Abstract;

namespace KariyerNetBackendTestCase.Dto.Base
{
    public abstract class PagedListRequestDtoBase: IDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
