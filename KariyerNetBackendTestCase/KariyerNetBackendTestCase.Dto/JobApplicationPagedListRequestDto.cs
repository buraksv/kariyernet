using KariyerNetBackendTestCase.Dto.Base;

namespace KariyerNetBackendTestCase.Dto
{
    public class JobApplicationPagedListRequestDto:PagedListRequestDtoBase
    {
        public long CompanyJobAdvertisementId { get; set; } 
    }
}
