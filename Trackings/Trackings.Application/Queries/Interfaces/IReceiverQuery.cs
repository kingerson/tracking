using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trackings.Application.Queries
{
    public interface IReceiverQuery
    {
        Task<IEnumerable<ReceiverViewModel>> findAll();
        Task<ReceiverViewModel> findById(int receiverId);

    }
}
