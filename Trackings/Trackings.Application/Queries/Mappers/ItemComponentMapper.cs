using Trackings.Application.Queries.ViewModels;

namespace Trackings.Application.Queries.Mappers
{
    public interface IItemComponentMapper
    {
        ItemComponentViewModel MapToItemComponentViewModel(dynamic r);
    }

    public class ItemComponentMapper : IItemComponentMapper
    {
        public ItemComponentViewModel MapToItemComponentViewModel(dynamic r)
        {
            ItemComponentViewModel o = new ItemComponentViewModel();

            o.itemComponentId = r.itemComponentId;
            o.name = r.name;
            o.typeLocalId = r.typeLocalId;
            o.wattsXm2 = r.wattsXm2;
            o.kiloWatts = r.kiloWatts;
            o.predecessor = r.predecessor;
            o.saleReport = r.saleReport;

            return o;
        }
    }
}
