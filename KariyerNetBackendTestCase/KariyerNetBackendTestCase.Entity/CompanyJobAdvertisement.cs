using System;
using System.Collections.Generic;
using KariyerNetBackendTestCase.Core.Entity.Abstract;
using KariyerNetBackendTestCase.Core.Entity.Base;

namespace KariyerNetBackendTestCase.Entity
{
    public class CompanyJobAdvertisement:Entity<long>,IHasCreatedTimeEntity,ICreatorUserAuditedEntity,IHasUpdatedTimeEntity,IModifierUserAuditedEntity,IStatusEntity
    {
        public long CompanyId { get; set; }
        public string AdvertisementName { get; set; }
        public string Description { get; set; }
        public short CountryId { get; set; }
        public int CityId { get; set; }
        public int TownId { get; set; }
        public DateTimeOffset ExpirationTime { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTimeOffset? UpdatedTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool IsActive { get; set; }

        public virtual Company Company { get; set; }
        public virtual List<JobApplication> JobApplications { get; set; }
    }
}
