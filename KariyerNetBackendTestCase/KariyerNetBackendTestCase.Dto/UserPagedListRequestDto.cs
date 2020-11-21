using KariyerNetBackendTestCase.Dto.Base;

namespace KariyerNetBackendTestCase.Dto
{
    public class UserPagedListRequestDto:PagedListRequestDtoBase
    {
        public string SearchTerm { get; set; }
    }
}
