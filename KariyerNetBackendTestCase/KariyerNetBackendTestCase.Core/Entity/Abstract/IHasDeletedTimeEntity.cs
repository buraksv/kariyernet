using System;

namespace KariyerNetBackendTestCase.Core.Entity.Abstract
{
    public interface IHasDeletedTimeEntity
    {
        /// <summary>
        /// ilgili kaydın Tenant Id Numarası
        /// </summary>
        DateTimeOffset? DeletedTime { get; set; }
    }
}
