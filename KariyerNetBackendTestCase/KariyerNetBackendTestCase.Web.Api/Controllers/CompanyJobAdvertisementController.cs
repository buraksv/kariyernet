using KariyerNetBackendTestCase.Business.DataAccess.Abstract;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KariyerNetBackendTestCase.Web.Api.Controllers
{
    [Route("companyjobadvertisements")]
    [ApiController]
    public class CompanyJobAdvertisementController : ControllerBase
    {
        private readonly ICompanyJobAdvertisementManager _companyJobAdvertisementManager;

        public CompanyJobAdvertisementController(ICompanyJobAdvertisementManager companyJobAdvertisementManager)
        {
            _companyJobAdvertisementManager = companyJobAdvertisementManager;
        }

        [HttpGet("{page}/{pageSize}/{searchTerm}")]
        public IResult GetPagedList(int page, int pageSize, string searchTerm)
        {
            var request = new CompanyJobAdvertisementPagedListRequestDto
            {
                Page = page,
                PageSize = pageSize,
                SearchTerm = searchTerm
            };

            return _companyJobAdvertisementManager.GetPagedList(request);
        }
        [HttpPost("create")]
        public IResult Create(CompanyJobAdvertisementDto request)
        {
            return _companyJobAdvertisementManager.Add(request);
        }
        [HttpGet("{companyJobAdvertisementId}")]
        public IResult Get(long companyJobAdvertisementId)
        {

            return _companyJobAdvertisementManager.GetById(companyJobAdvertisementId);
        }
        [HttpDelete("delete/{companyJobAdvertisementId}")]
        public IResult Delete(long companyJobAdvertisementId)
        {

            return _companyJobAdvertisementManager.DeleteById(companyJobAdvertisementId);
        }

    }
}
