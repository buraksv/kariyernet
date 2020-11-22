using KariyerNetBackendTestCase.Business.DataAccess.Abstract;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KariyerNetBackendTestCase.Web.Api.Controllers
{
    [Route("companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyManager _companyManager;
        public CompanyController(ICompanyManager companyManager)
        {
            _companyManager = companyManager;
        }

        [HttpGet("{page}/{pageSize}/{searchTerm}")]
        public IResult GetPagedList(int page,int pageSize,string searchTerm)
        {
            var request=new CompanyPagedListRequestDto
            {
                Page = page,
                PageSize = pageSize,
                SearchTerm = searchTerm
            };

            return _companyManager.GetPagedList(request);
        }
        [HttpPost("create")]
        public IResult Create([FromForm] CompanyDto request)
        {

            return _companyManager.Add(request);
        }
        [HttpGet("{companyId}")]
        public IResult Get(long companyId)
        { 
            return _companyManager.GetById(companyId);
        }
        [HttpPut("update")]
        public IResult Update(CompanyDto request)
        {

            return _companyManager.Update(request);
        }
        [HttpDelete("delete/{companyId}")]
        public IResult Delete(long companyId)
        {

            return _companyManager.DeleteById(companyId);
        }

    }
}
