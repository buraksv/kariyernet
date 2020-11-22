using KariyerNetBackendTestCase.Core.Entity;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.Dto;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.Business.DataAccess.Abstract
{
    public interface IUserManager
    {
        IDataResult<UserDto> Add(UserDto userDto);
        IDataResult<UserDto> GetById(long userId);
        IDataResult<UserDto> Update(UserDto userDto);
        IDataResult<PagedResult<User>> GetPagedList(UserPagedListRequestDto requestDto);
        IDataResult<int> DeleteById(long userId);
        IDataResult<bool> CheckUserCv(long userId);

    }
}
