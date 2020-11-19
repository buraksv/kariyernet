namespace KariyerNetBackendTestCase.Core.Entity.Abstract
{
    /// <summary>
    /// Eklenen kayıtta Kayıt Aktiflik durumu alanı olması isteniyorsa bu Interface Implemente edilmelidir
    /// </summary>
    public interface IStatusEntity
    {
        /// <summary>
        /// Kayıt görünür olacaksa bu alan 'true' olmalıdır
        /// </summary>
         bool IsActive { get; set; }
    }
}
