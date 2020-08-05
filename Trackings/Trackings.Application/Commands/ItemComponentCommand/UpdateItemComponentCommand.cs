using MediatR;

namespace Trackings.Application.Commands
{
    public class UpdateItemComponentCommand : IRequest<int>
    {
        public int itemComponentId { get; set; }
        public string name { get; set; }
        public int? typeLocalId { get; set; }
        public decimal? wattsXm2 { get; set; }
        public decimal? kiloWatts { get; set; }
        public int predecessor { get; set; }
        public bool? saleReport { get; set; }
    }
}
