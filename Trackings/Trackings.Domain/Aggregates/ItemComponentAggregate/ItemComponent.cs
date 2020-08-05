using Trackings.Domain.Core;

namespace Trackings.Domain.Aggregates
{
    public class ItemComponent : Entity
    {
        public int itemComponentId { get; set; }
        public string name { get; set; }
        public int? typeLocalId { get; set; }
        public decimal? wattsXm2 { get; set; }
        public decimal? kiloWatts { get; set; }
        public int predecessor { get; set; }
        public bool? saleReport { get; set; }

        public ItemComponent()
        {
        }

        public ItemComponent(string name, int? typeLocalId, decimal? wattsXm2, decimal? kiloWatts, int predecessor, bool? saleReport)
        {
            this.name = name;
            this.typeLocalId = typeLocalId;
            this.wattsXm2 = wattsXm2;
            this.kiloWatts = kiloWatts;
            this.predecessor = predecessor;
            this.saleReport = saleReport;
        }

        public ItemComponent(int itemComponentId, string name, int? typeLocalId, decimal? wattsXm2, decimal? kiloWatts, int predecessor, bool? saleReport)
        {
            this.itemComponentId = itemComponentId;
            this.name = name;
            this.typeLocalId = typeLocalId;
            this.wattsXm2 = wattsXm2;
            this.kiloWatts = kiloWatts;
            this.predecessor = predecessor;
            this.saleReport = saleReport;
        }
    }
}
