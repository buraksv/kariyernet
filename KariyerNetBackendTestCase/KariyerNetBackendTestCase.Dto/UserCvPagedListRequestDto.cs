using KariyerNetBackendTestCase.Dto.Base;

namespace KariyerNetBackendTestCase.Dto
{
    public class UserCvPagedListRequestDto:PagedListRequestDtoBase
    {
        public string SearchTerm { get; set; }
    }
}
