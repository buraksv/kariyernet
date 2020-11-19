namespace KariyerNetBackendTestCase.Core.Entity.Abstract
{
    /// <summary>
    /// Kayıt silinmek istediği zaman direkt silinmek yerine 'Silindi' olarak işaretlenmesi için bu Interface Implemente edilmelidir
    /// </summary>
    public interface ITrashableEntity
    {
        /// <summary>
        /// Kayıt silinmişse bu alan 'true' olmalıdır
        /// </summary>
         bool IsDeleted { get; set; }
    }
}
