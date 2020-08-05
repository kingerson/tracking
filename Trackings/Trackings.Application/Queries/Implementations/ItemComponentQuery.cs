using Trackings.Application.Queries.Interfaces;
using Trackings.Application.Queries.Mappers;
using Trackings.Application.Queries.ViewModels;
using RealPlaza.Libs.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trackings.Application.Queries.Implementations
{
    public class ItemComponentQuery : IItemComponentQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly IItemComponentMapper _iItemComponentMapper;

        public ItemComponentQuery(IGenericQuery iGenericQuery, IItemComponentMapper iItemComponentMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iItemComponentMapper = iItemComponentMapper ?? throw new ArgumentNullException(nameof(iItemComponentMapper));
        }

        public async Task<ItemComponentViewModel> GetById(int itemComponentId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"rubro_c_yid", itemComponentId}
            };

            var result = await _iGenericQuery.SearchAsync(@"dbo.ADV_T_RUBRO_search", ConvertTo.Xml(parameters));

            return (result != null) ? _iItemComponentMapper.MapToItemComponentViewModel(result) : null;
        }

        public async Task<IEnumerable<ItemComponentViewModel>> GetBySearch(ItemComponentRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"rubro_c_yid", request.itemComponentId}
            };

            var result = await _iGenericQuery.SearchAsync(@"dbo.ADV_T_RUBRO_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (ItemComponentViewModel)_iItemComponentMapper.MapToItemComponentViewModel(item));

            return items;
        }

        public async Task<PaginationViewModel<ItemComponentViewModel>> GetByFindAll(ItemComponentRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"rubro_c_yid", request.itemComponentId}
            };

            var result = await _iGenericQuery.FindAllAsync(@"dbo.ADV_T_RUBRO_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (ItemComponentViewModel)_iItemComponentMapper.MapToItemComponentViewModel(item));

            return new PaginationViewModel<ItemComponentViewModel>(request.pagination, items);
        }
    }
}
