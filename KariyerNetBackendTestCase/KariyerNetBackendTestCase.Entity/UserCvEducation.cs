using KariyerNetBackendTestCase.Core.Entity.Base;
using KariyerNetBackendTestCase.Enum;

namespace KariyerNetBackendTestCase.Entity
{
    public class UserCvEducation:Entity<long>
    {
        public long UserCvId { get; set; }
        public SchoolLevelEnum SchoolLevel { get; set; }
        public string SchoolName { get; set; }
        public short StartYear { get; set; }
        public short? EndYear { get; set; }
        public bool IsAbandoned { get; set; }
        public decimal GradeAverage { get; set; }

        public virtual UserCv UserCvDetail { get; set; }

    }
}
