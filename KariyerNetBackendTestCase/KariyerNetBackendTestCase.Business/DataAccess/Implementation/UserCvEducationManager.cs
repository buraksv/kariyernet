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
    public class UserCvEducationManager:IUserCvEducationManager
    {
        private readonly IUserCvEducationDal _userCvEducationDal;
        private readonly IMapper _mapper;

        public UserCvEducationManager(IUserCvEducationDal userCvEducationDal, IMapper mapper)
        {
            _userCvEducationDal = userCvEducationDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(UserCvEducationValidator))]
        public IDataResult<UserCvEducationDto> Add(UserCvEducationDto userCvEducationDto)
        {
            var request = _mapper.Map<UserCvEducation>(userCvEducationDto);

            _userCvEducationDal.Add(request);
            _userCvEducationDal.Save();

            return new SuccessDataResult<UserCvEducationDto>(_mapper.Map<UserCvEducationDto>(request));
        }

        public IDataResult<List<UserCvEducationDto>> GetByUserCvId(long userCvId)
        {
            var result = _userCvEducationDal.GetFirstOrDefault(x => x.Id == userCvId);

            if (result == null) return new ErrorDataResult<List<UserCvEducationDto>>();

            return new SuccessDataResult<List<UserCvEducationDto>>(_mapper.Map<List<UserCvEducationDto>>(result));
        }

        public IDataResult<int> DeleteByUserEducationId(long userEducationId)
        {
            _userCvEducationDal.Delete(userEducationId);
            var count = _userCvEducationDal.Save();

            return new SuccessDataResult<int>(count);
        }
    }
}
