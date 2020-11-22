using System;
using KariyerNetBackendTestCase.Core.Entity.Abstract;

namespace KariyerNetBackendTestCase.Dto
{
    public class CompanyDto:IDto
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTimeOffset? UpdatedTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTimeOffset? DeletedTime { get; set; }
        public long? DeleterUserId { get; set; }
        public bool IsActive { get; set; } 
         
    }
}
