using System;
using KariyerNetBackendTestCase.Core.Entity.Abstract;
using KariyerNetBackendTestCase.Core.Entity.Base;

namespace KariyerNetBackendTestCase.Entity
{
    public class User:Entity<long>,IHasCreatedTimeEntity,ITrashableEntity,IStatusEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long? UserCvId { get; set; }
        public DateTime BornDate { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

    }
}
