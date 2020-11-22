using System;
using KariyerNetBackendTestCase.Core.Entity.Abstract;
using KariyerNetBackendTestCase.Enum;

namespace KariyerNetBackendTestCase.Dto
{
    public class UserCvWorkingExperienceDto:IDto
    {
        public long Id { get; set; }
        public long UserCvId { get; set; }
        public CompanySectorEnum CompanySector { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string WorkDetail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short Country { get; set; }
        public int City { get; set; } 
         
    }
}
