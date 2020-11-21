using System.Collections.Generic;
using AutoMapper;
using KariyerNetBackendTestCase.Business.DataAccess.Abstract;
using KariyerNetBackendTestCase.Business.Validation;
using KariyerNetBackendTestCase.Core.Aspects.Validation;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.Dto;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.Business.DataAccess.Implementation
{
    public class UserCvWorkExperienceManager:IUserCvWorkExperienceManager
    {
        private readonly IUserCvWorkExperienceDal _userCvWorkExperienceDal;
        private readonly IMapper _mapper;


        public UserCvWorkExperienceManager(IUserCvWorkExperienceDal userCvWorkExperienceDal, IMapper mapper)
        {
            _userCvWorkExperienceDal = userCvWorkExperienceDal;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(UserCvWorkExperienceValidator))]
        public IDataResult<UserCvWorkingExperienceDto> Add(UserCvWorkingExperienceDto userCvWorkingExperienceDto)
        {
            var request = _mapper.Map<UserCvWorkingExperience>(userCvWorkingExperienceDto);

            _userCvWorkExperienceDal.Add(request);
            _userCvWorkExperienceDal.Save();

            return new SuccessDataResult<UserCvWorkingExperienceDto>(_mapper.Map<UserCvWorkingExperienceDto>(request));
        }

        public IDataResult<List<UserCvWorkingExperienceDto>> GetByUserCvId(long userCvId)
        {
            var result = _userCvWorkExperienceDal.GetFirstOrDefault(x => x.Id == userCvId);

            if (result == null) return new ErrorDataResult<List<UserCvWorkingExperienceDto>>();

            return new SuccessDataResult<List<UserCvWorkingExperienceDto>>(_mapper.Map<List<UserCvWorkingExperienceDto>>(result));
        }

        public IDataResult<int> DeleteByUserWorkingExperienceId(long workingExperienceId)
        {
            _userCvWorkExperienceDal.Delete(workingExperienceId);
            var count = _userCvWorkExperienceDal.Save();

            return new SuccessDataResult<int>(count);
        }
    }
}
