using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trackings.Application.Queries
{
    public interface IStateQuery
    {
        Task<IEnumerable<StateViewModel>> findAll();
        Task<StateViewModel> findById(int parentId, int userTypeId);
    }
}
