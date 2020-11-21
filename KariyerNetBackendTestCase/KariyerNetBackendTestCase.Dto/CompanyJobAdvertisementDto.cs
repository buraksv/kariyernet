using System;
using KariyerNetBackendTestCase.Core.Entity.Abstract;

namespace KariyerNetBackendTestCase.Dto
{
    public class CompanyJobAdvertisementDto:IDto
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
        public bool IsActive { get; set; }
        public DateTimeOffset? UpdatedTime { get; set; }
        public long? LastModifierUserId { get; set; }
         
    }
}
