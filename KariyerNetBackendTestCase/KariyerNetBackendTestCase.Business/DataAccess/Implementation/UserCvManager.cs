using System;
using AutoMapper;
using KariyerNetBackendTestCase.Business.DataAccess.Abstract;
using KariyerNetBackendTestCase.Business.Validation;
using KariyerNetBackendTestCase.Core.Aspects.Validation;
using KariyerNetBackendTestCase.Core.Entity;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.Dto;
using KariyerNetBackendTestCase.Entity; 

namespace KariyerNetBackendTestCase.Business.DataAccess.Implementation
{
    public class UserCvManager:IUserCvManager
    {
        private readonly IUserCvDal _userCvDal;
        private readonly IMapper _mapper;


        public UserCvManager(IUserCvDal userCvDal, IMapper mapper)
        {
            _userCvDal = userCvDal;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(UserCvValidator))]
        public IDataResult<UserCvDto> Add(UserCvDto userCv)
        {
            var request = _mapper.Map<UserCv>(userCv);
            request.CreatedTime=DateTimeOffset.Now;

            _userCvDal.Add(request);
            _userCvDal.Save();

            return new SuccessDataResult<UserCvDto>(_mapper.Map<UserCvDto>(request));
        }

        public IDataResult<UserCvDto> GetById(long userCvId)
        {
            var result = _userCvDal.GetFirstOrDefault(x => x.Id == userCvId);

            if (result == null) return new ErrorDataResult<UserCvDto>();

            return new SuccessDataResult<UserCvDto>(_mapper.Map<UserCvDto>(result));
        }
        [ValidationAspect(typeof(UserCvValidator))]
        public IDataResult<UserCvDto> Update(UserCvDto userDvCv)
        {
            var requestEntity = _mapper.Map<UserCv>(userDvCv);

            _userCvDal.Update(requestEntity);
            _userCvDal.Save();

            return new SuccessDataResult<UserCvDto>(userDvCv);
        }
         
    }
}
