using System;
using KariyerNetBackendTestCase.Core.Entity.Base;
using KariyerNetBackendTestCase.Enum;

namespace KariyerNetBackendTestCase.Entity
{
    public class UserCvWorkingExperience:Entity<long>
    {
        public long UserCvId { get; set; }
        public CompanySectorEnum CompanySector { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string WorkDetail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short CountryId { get; set; }
        public int CityId { get; set; }

        public virtual UserCv UserCvDetail { get; set; }
    }
}
