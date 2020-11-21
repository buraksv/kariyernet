using KariyerNetBackendTestCase.Core.Entity;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.Dto;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.Business.DataAccess.Abstract
{
    public interface IUserCvManager
    {
        IDataResult<UserCvDto> Add(UserCvDto userCv);
        IDataResult<UserCvDto> GetById(long userCvId);
        IDataResult<UserCvDto> Update(UserCvDto userDvCv);
        IDataResult<PagedResult<UserCv>> GetPagedList(UserCvPagedListRequestDto requestDto);
    }
}
