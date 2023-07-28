using NopClone.Data.Entities.Base;
using NopClone.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopClone.Data.Entities
{
    public class Product : BaseEntity<int>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public bool ShowOnHomePage { get; set; }

        public int Rating { get; set; }
        public int StockQty { get; set; }

        public string ManufacturerID { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public IList<Image>? Images { get; set; }

        public IList<ProductCategory> Categories { get; set; }

        public IList<SpecificationAttribute> Attributes { get; set; }
    }
}
