namespace KariyerNetBackendTestCase.Core.Entity.Abstract
{
    /// <summary>
    /// Kayıtlar üzerinde kaydı silen kullanıcı bilgisinin tutulması isteniyorsa bu Interface Implemente edilmelidir.
    /// </summary>
    public interface IDeleterUserAuditedEntity
    {
        /// <summary>
        /// Which user deleted this entity?
        /// </summary>
        long? DeleterUserId { get; set; }
    }
}
