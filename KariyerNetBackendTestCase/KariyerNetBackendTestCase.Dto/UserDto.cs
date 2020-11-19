using System;
using KariyerNetBackendTestCase.Core.Entity.Abstract;

namespace KariyerNetBackendTestCase.Dto
{
    public class UserDto:IDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long? UserCvId { get; set; }
        public DateTimeOffset CreatedTime { get; set; } 
        public bool IsActive { get; set; }

    }
}
