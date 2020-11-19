using System;
using System.Collections.Generic;
using KariyerNetBackendTestCase.Core.Entity.Abstract;
using KariyerNetBackendTestCase.Core.Entity.Base;

namespace KariyerNetBackendTestCase.Entity
{
    public class Company:Entity<long>,IHasCreatedTimeEntity,ICreatorUserAuditedEntity,IHasUpdatedTimeEntity,IModifierUserAuditedEntity,IHasDeletedTimeEntity,IDeleterUserAuditedEntity,IStatusEntity,ITrashableEntity
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTimeOffset? UpdatedTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTimeOffset? DeletedTime { get; set; }
        public long? DeleterUserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<CompanyJobAdvertisement> CompanyJobAdvertisements { get; set; }
    }
}
