using System;
using KariyerNetBackendTestCase.Core.Entity.Abstract;

namespace KariyerNetBackendTestCase.Dto
{
    public class JobApplicationDto:IDto
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
    }
}
