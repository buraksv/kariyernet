namespace KariyerNetBackendTestCase.Core.Entity.Abstract
{
    public interface IEntity
    {

    }
    /// <summary>
    /// Veritabanındaki bir tabloya karşılık gelen kayıtlar için bu Interface implemente edilmelidir.
    /// </summary>
    /// <typeparam name="TPrimaryKey">İlgili Kaytın Primary Key Tipi</typeparam>
    public interface IEntity<TPrimaryKey> : IEntity
        where TPrimaryKey : struct
    {
        TPrimaryKey Id { get; set; }

        string GetIdString();

    }
}
