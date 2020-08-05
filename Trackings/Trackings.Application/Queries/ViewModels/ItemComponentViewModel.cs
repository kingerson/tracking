using RealPlaza.Libs.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trackings.Application.Queries.ViewModels
{
    public class ItemComponentViewModel
    {
        public int itemComponentId { get; set; }
        public string name { get; set; }
        public int? typeLocalId { get; set; }
        public decimal? wattsXm2 { get; set; }
        public decimal? kiloWatts { get; set; }
        public int predecessor { get; set; }
        public bool? saleReport { get; set; }
    }

    public class ItemComponentRequest : PaginationRequest
    {
        public int itemComponentId { get; set; }
    }
}
