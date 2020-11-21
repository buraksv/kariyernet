using System.Collections.Generic;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.Dto;

namespace KariyerNetBackendTestCase.Business.DataAccess.Abstract
{
    public interface IUserCvEducationManager
    {
        IDataResult<UserCvEducationDto> Add(UserCvEducationDto userCvEducationDto);
        IDataResult<List<UserCvEducationDto>> GetByUserCvId(long userCvId);
        IDataResult<int> DeleteByUserEducationId(long userEducationId);
         
    }
}
