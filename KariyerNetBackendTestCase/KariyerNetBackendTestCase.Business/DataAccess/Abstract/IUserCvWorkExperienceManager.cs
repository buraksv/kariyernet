using System.Collections.Generic;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.Dto;

namespace KariyerNetBackendTestCase.Business.DataAccess.Abstract
{
    public interface IUserCvWorkExperienceManager
    {
        IDataResult<UserCvWorkingExperienceDto> Add(UserCvWorkingExperienceDto userCvWorkingExperienceDto);
        IDataResult<List<UserCvWorkingExperienceDto>> GetByUserCvId(long userCvId);
        IDataResult<int> DeleteByUserWorkingExperienceId(long workingExperienceId);

    }
}
