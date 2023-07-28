using NopClone.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopClone.Data.Entities
{
    public class Manufacturer : BaseEntity<string>
    {
        public string Name { get; set; }
        
        public string? ImageID { get; set; }
        public Image? Image { get; set; }
    }
}
