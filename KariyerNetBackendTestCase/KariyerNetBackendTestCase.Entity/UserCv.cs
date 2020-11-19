using System;
using System.Collections.Generic;
using KariyerNetBackendTestCase.Core.Entity.Abstract;
using KariyerNetBackendTestCase.Core.Entity.Base;

namespace KariyerNetBackendTestCase.Entity
{
    public class UserCv : Entity<long>, IHasCreatedTimeEntity, IHasUpdatedTimeEntity
    {
        public string SummaryInformation { get; set; }
        public string JobTitle { get; set; }
        public short CountryId { get; set; }
        public int CityId { get; set; }
        public int TownId { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset? UpdatedTime { get; set; }

        public virtual List<UserCvEducation> EducationDetails { get; set; }
        public virtual List<UserCvWorkingExperience> WorkingExperiences { get; set; }
    }
}
