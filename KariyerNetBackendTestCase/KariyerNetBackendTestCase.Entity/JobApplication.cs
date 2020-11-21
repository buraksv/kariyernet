using System;
using KariyerNetBackendTestCase.Core.Entity.Abstract;
using KariyerNetBackendTestCase.Core.Entity.Base;

namespace KariyerNetBackendTestCase.Entity
{
    public class JobApplication:Entity<Guid>,IHasCreatedTimeEntity,ITrashableEntity,IHasDeletedTimeEntity,IDeleterUserAuditedEntity
    {
        public long UserId { get; set; }
        public long CompanyJobAdvertisementId { get; set; }
        public string ApplicationLetter { get; set; }
        public bool IsViewed { get; set; }
        public DateTimeOffset? ViewTime { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedTime { get; set; }
        public long? DeleterUserId { get; set; }

        public User User { get; set; }
        public CompanyJobAdvertisement CompanyJobAdvertisement { get; set; }

    }
}
