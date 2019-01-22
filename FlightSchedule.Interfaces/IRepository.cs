using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightSchedule.Interfaces
{
    public interface IRepository<TEntity, TSearchQuery>
    {
      IEnumerable<TEntity> Search(TSearchQuery searchQuery);
    }
}
