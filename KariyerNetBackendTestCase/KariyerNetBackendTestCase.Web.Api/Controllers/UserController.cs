using KariyerNetBackendTestCase.Business.DataAccess.Abstract;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KariyerNetBackendTestCase.Web.Api.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCvManager _userCvManager;
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager, IUserCvManager userCvManager)
        {
            _userManager = userManager;
            _userCvManager = userCvManager;
        }

        [HttpGet("{page}/{pageSize}/{searchTerm}")]
        public IResult GetPagedList(int page, int pageSize, string searchTerm)
        {
            var request = new UserPagedListRequestDto
            {
                Page = page,
                PageSize = pageSize,
                SearchTerm = searchTerm
            };

            return _userManager.GetPagedList(request);
        }
        [HttpPost("create")]
        public IResult Create(UserDto request)
        {

            return _userManager.Add(request);
        }
        [HttpGet("{userId}")]
        public IResult Get(long userId)
        {

            return _userManager.GetById(userId);
        }
        [HttpPut("update")]
        public IResult Update(UserDto request)
        {

            return _userManager.Update(request);
        }
        [HttpDelete("delete/{userId}")]
        public IResult Delete(long userId)
        {

            return _userManager.DeleteById(userId);
        }


        [HttpPost("cv/create")]
        public IResult CreateDv(UserCvDto request)
        {

            return _userCvManager.Add(request);
        }
        [HttpGet("cv/{userCvId}")]
        public IResult GetDv(long userCvId)
        {

            return _userCvManager.GetById(userCvId);
        }
        [HttpPut("cv/update")]
        public IResult UpdateCv(UserCvDto request)
        {

            return _userCvManager.Update(request);
        }

    }
}
