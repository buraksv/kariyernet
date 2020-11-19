using System;

namespace KariyerNetBackendTestCase.Core.Entity.Abstract
{
    public interface IHasCreatedTimeEntity
    {
        /// <summary>
        /// Created date of this entity.
        /// </summary>
        DateTimeOffset CreatedTime { get; set; }
    }
}
