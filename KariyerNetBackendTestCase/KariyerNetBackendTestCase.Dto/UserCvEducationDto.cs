using KariyerNetBackendTestCase.Core.Entity.Abstract;
using KariyerNetBackendTestCase.Enum;

namespace KariyerNetBackendTestCase.Dto
{
    public class UserCvEducationDto:IDto
    {
        public long UserCvId { get; set; }
        public SchoolLevelEnum SchoolLevel { get; set; }
        public string SchoolName { get; set; }
        public short StartYear { get; set; }
        public short? EndYear { get; set; }
        public bool IsAbandoned { get; set; }
        public decimal GradeAverage { get; set; }
         

    }
}
