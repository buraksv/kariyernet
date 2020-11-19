using System;

namespace KariyerNetBackendTestCase.Core.Entity.Abstract
{
    public interface IHasUpdatedTimeEntity
    {
        /// <summary>
        /// Last modification date of this entity.
        /// </summary>
        DateTimeOffset? UpdatedTime { get; set; }
    }
}
