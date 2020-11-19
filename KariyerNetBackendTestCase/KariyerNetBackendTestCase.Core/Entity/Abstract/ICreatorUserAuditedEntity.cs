namespace KariyerNetBackendTestCase.Core.Entity.Abstract
{
    /// <summary>
    /// Kayıtlar üzerinde eklenen kaydı ekleyen kullanıcı bilgisinin tutulması isteniyorsa bu Interface Implemente edilmelidir.
    /// </summary>
    public interface ICreatorUserAuditedEntity
    {
        /// <summary>
        /// Creator of this entity.
        /// </summary>
         long? CreatorUserId { get; set; }
    }
}
