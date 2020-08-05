using Trackings.Application.Queries.ViewModels;
using RealPlaza.Libs.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trackings.Application.Queries.Interfaces
{
    public interface IItemComponentQuery
    {
        Task<ItemComponentViewModel> GetById(int itemComponentId);
        Task<IEnumerable<ItemComponentViewModel>> GetBySearch(ItemComponentRequest request);
        Task<PaginationViewModel<ItemComponentViewModel>> GetByFindAll(ItemComponentRequest request);
    }
}
