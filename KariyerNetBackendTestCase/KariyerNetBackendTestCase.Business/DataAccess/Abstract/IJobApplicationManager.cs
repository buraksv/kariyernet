using System;
using KariyerNetBackendTestCase.Core.Entity;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.Dto;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.Business.DataAccess.Abstract
{
    public interface IJobApplicationManager
    {
        IDataResult<JobApplicationDto> ApplyJob(JobApplicationDto jobApplicationDto);
        IDataResult<JobApplicationDto> GetById(Guid jobApplicationId);
        IDataResult<PagedResult<JobApplication>> GetPagedList(JobApplicationPagedListRequestDto requestDto);
        IDataResult<int> DeleteById(Guid jobApplicationId);
        IDataResult<bool> SetViewed(Guid jobApplicationId);
    }
}
