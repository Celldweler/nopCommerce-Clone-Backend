using NopClone.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopClone.Data.Entities
{
    public class Category : BaseEntity<string>
    {
        public string Name { get; set; }

        public int Depth { get; set; }
        public string? ViewPath { get; set; }
        public bool ShowOnHomePage { get; set; }
        public bool IncludeInTopMenu { get; set; }
        public int DisplayOrder { get; set; }

        public Category? Parent { get; set; }
        public string? ParentId { get; set; }


        public IList<Category>? SubCategories { get; set; }

        public IList<ProductCategory> Products { get; set; }

        public string? ImageId { get; set; }
        public Image? Image { get; set; }
    }
}
