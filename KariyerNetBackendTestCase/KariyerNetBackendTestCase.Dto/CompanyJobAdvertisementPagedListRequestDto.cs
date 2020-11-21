using KariyerNetBackendTestCase.Dto.Base;

namespace KariyerNetBackendTestCase.Dto
{
    public class CompanyJobAdvertisementPagedListRequestDto:PagedListRequestDtoBase
    {
        public string SearchTerm { get; set; }
    }
}
