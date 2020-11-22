using KariyerNetBackendTestCase.Dto.Base;

namespace KariyerNetBackendTestCase.Dto
{
    public class CompanyPagedListRequestDto:PagedListRequestDtoBase
    {
         public string SearchTerm { get; set; }
    }
}
