namespace KariyerNetBackendTestCase.Core.Entity.Abstract
{
    /// <summary>
    /// Kayıtlar üzerinde kaydı güncelleyen kullanıcı bilgisinin tutulması isteniyorsa bu Interface Implemente edilmelidir.
    /// </summary>
    public interface IModifierUserAuditedEntity
    {
        /// <summary>
        /// Last modifier user of this entity.
        /// </summary>
        long? LastModifierUserId { get; set; }
    }
}
