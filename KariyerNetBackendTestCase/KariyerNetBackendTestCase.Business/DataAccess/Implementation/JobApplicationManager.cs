using System;
using AutoMapper;
using KariyerNetBackendTestCase.Business.DataAccess.Abstract;
using KariyerNetBackendTestCase.Business.Validation;
using KariyerNetBackendTestCase.Core.Aspects.Validation;
using KariyerNetBackendTestCase.Core.Entity;
using KariyerNetBackendTestCase.Core.Utilities.Business;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.Dto;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.Business.DataAccess.Implementation
{
    public class JobApplicationManager : IJobApplicationManager
    {
        private readonly IJobApplicationDal _jobApplicationDal;
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        public JobApplicationManager(IJobApplicationDal jobApplicationDal, IUserDal userDal, IMapper mapper)
        {
            _jobApplicationDal = jobApplicationDal;
            _userDal = userDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(JobApplicationValidator))]
        public IDataResult<JobApplicationDto> ApplyJob(JobApplicationDto jobApplicationDto)
        {

            var rulesResult = BusinessRuleRunner.Run(out var errorMessages,() => CheckUserCvIfExists(jobApplicationDto));

            if (rulesResult)
                return new ErrorDataResult<JobApplicationDto>(jobApplicationDto,string.Join(",",errorMessages));

            var entityData = _mapper.Map<JobApplication>(jobApplicationDto);
            entityData.CreatedTime = DateTimeOffset.Now;

            _jobApplicationDal.Add(entityData);
            _jobApplicationDal.Save();

            return new SuccessDataResult<JobApplicationDto>(_mapper.Map<JobApplicationDto>(entityData));

        }

        public IDataResult<JobApplicationDto> GetById(Guid jobApplicationId)
        {
            var result = _jobApplicationDal.GetFirstOrDefault(x=>x.Id==jobApplicationId && x.IsDeleted==false);

            if (result == null) return new ErrorDataResult<JobApplicationDto>();

            return new SuccessDataResult<JobApplicationDto>(_mapper.Map<JobApplicationDto>(result));
        }
         
        public IDataResult<PagedResult<JobApplication>> GetPagedList(JobApplicationPagedListRequestDto requestDto)
        {
            var result = _jobApplicationDal.GetPagedList(requestDto.Page, requestDto.PageSize,
                x => x.CompanyJobAdvertisementId == requestDto.CompanyJobAdvertisementId && x.IsDeleted==false);

            return new SuccessDataResult<PagedResult<JobApplication>>(result);
        }

        public IDataResult<int> DeleteById(Guid jobApplicationId)
        {
             _jobApplicationDal.MoveToTrash(jobApplicationId);
            var count=_jobApplicationDal.Save();

            return new SuccessDataResult<int>(count);
        }

        public IDataResult<bool> SetViewed(Guid jobApplicationId)
        {
            var entity = _jobApplicationDal.GetFirstOrDefault(x => x.Id == jobApplicationId && x.IsDeleted == false);

            if (entity == null) return new ErrorDataResult<bool>(false,"Kayıt Bulunamadı");

            entity.IsViewed = true;
            entity.ViewTime=DateTimeOffset.Now;

            _jobApplicationDal.Update(entity);
            _jobApplicationDal.Save();

            return new SuccessDataResult<bool>(true);
        }
        
        private void CheckUserCvIfExists(JobApplicationDto jobApplicationDto)
        {
           var userCvControl= _userDal.Exists(x => x.Id == jobApplicationDto.UserId && x.IsDeleted == false && x.IsActive && x.UserCvId!=null);

           if(!userCvControl) throw new Exception("Kullanıcının CV si olmadığı için başvuru yapamaz");
        }
    }
}
