using NopClone.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopClone.Data.Entities
{
    public class Image : BaseEntity<string>
    {
        public string FileName { get; set; }
        public string Type { get; set; }
        public bool IsPreview { get; set; } 
        
        public string? MimeType { get; set; }
        public int OrderDisplay { get; set; }
    }

    public enum ImageType
    {
        Product,
        Category
    }

    public struct ImageTypes
    {
        public static string Product = nameof(Product);
        public static string Category = nameof(Category);
    }
}
