using System;
using KariyerNetBackendTestCase.Core.Entity.Abstract;

namespace KariyerNetBackendTestCase.Dto
{
    public class UserCvDto : IDto
    {
        public long Id { get; set; }
        public string SummaryInformation { get; set; }
        public string JobTitle { get; set; }
        public short Country { get; set; }
        public int City { get; set; }
        public int Town { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BornDate { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset? UpdatedTime { get; set; }
 
    }
}
