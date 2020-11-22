using System;
using KariyerNetBackendTestCase.Business.DataAccess.Abstract;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KariyerNetBackendTestCase.Web.Api.Controllers
{
    [Route("jobapplications")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationManager _jobApplicationManager;

        public JobApplicationController(IJobApplicationManager jobApplicationManager)
        {
            _jobApplicationManager = jobApplicationManager;
        }


        [HttpGet("{page}/{pageSize}/{companyJobAdvertisementId}")]
        public IResult GetPagedList(int page, int pageSize, long CompanyJobAdvertisementId)
        {
            var request = new JobApplicationPagedListRequestDto
            {
                Page = page,
                PageSize = pageSize,
                CompanyJobAdvertisementId = CompanyJobAdvertisementId
            };

            return _jobApplicationManager.GetPagedList(request);
        }
        [HttpPost("applyJob")]
        public IResult ApplyJob(JobApplicationDto request)
        {

            return _jobApplicationManager.ApplyJob(request);
        }
        [HttpPost("setViewed/{jobApplicationId}")]
        public IResult SetViewed(Guid jobApplicationId)
        {

            return _jobApplicationManager.SetViewed(jobApplicationId);
        }
        [HttpGet("{jobApplicationId}")]
        public IResult Get(Guid jobApplicationId)
        {

            return _jobApplicationManager.GetById(jobApplicationId);
        }
 
        [HttpDelete("delete/{jobApplicationId}")]
        public IResult Delete(Guid jobApplicationId)
        {

            return _jobApplicationManager.DeleteById(jobApplicationId);
        }


    }
}
