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
    public class UserManager:IUserManager
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IDataResult<UserDto> Add(UserDto userDto)
        {
            var request = _mapper.Map<User>(userDto);
            request.CreatedTime=DateTimeOffset.Now;
            

            _userDal.Add(request);
            _userDal.Save();

            return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(request));
        }
        public IDataResult<UserDto> GetById(long userId)
        {
            var result = _userDal.GetFirstOrDefault(x => x.Id == userId && x.IsDeleted==false);

            if (result == null) return new ErrorDataResult<UserDto>();

            return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(result));
        }
        [ValidationAspect(typeof(UserValidator))]
        public IDataResult<UserDto> Update(UserDto userDto)
        {
            var requestEntity = _mapper.Map<User>(userDto);

            _userDal.Update(requestEntity);
            _userDal.Save();

            return new SuccessDataResult<UserDto>(userDto);
        }
        public IDataResult<PagedResult<User>> GetPagedList(UserPagedListRequestDto requestDto)
        {
            var result = _userDal.GetPagedList(requestDto.Page, requestDto.PageSize,
                x => (x.UserName.Contains(requestDto.SearchTerm) || x.Email.Contains(requestDto.SearchTerm) )&& x.IsDeleted == false);

            return new SuccessDataResult<PagedResult<User>>(result);
        }
        public IDataResult<int> DeleteById(long userId)
        {
            _userDal.MoveToTrash(userId);
            var count = _userDal.Save();

            return new SuccessDataResult<int>(count);
        }

        public IDataResult<bool> CheckUserCv(long userId)
        {
            var control= _userDal.Exists(x => x.Id == userId && x.IsDeleted == false && x.IsActive && x.UserCvId != null);

            return new SuccessDataResult<bool>(control); 
        }
    }
}
