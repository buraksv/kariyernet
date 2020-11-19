using KariyerNetBackendTestCase.Core.Entity.Abstract;

namespace KariyerNetBackendTestCase.Core.Entity.Base
{
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        public TPrimaryKey Id { get; set; } 
        public virtual TPrimaryKey GetId() => Id;
        public virtual string GetIdString() => Id.ToString(); 
   
        public override string ToString() => $"[{GetType().Name} - {Id}]";
 
    }
}
