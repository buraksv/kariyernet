using System.Threading.Tasks;

namespace KariyerNetBackendTestCase.Core.DataAccess.Abstract
{
    public interface ISaveableRepository
    {
        int Save();
        Task<int> SaveAsync();
    }
}
