using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopClone.Data.Entities.Base
{
    public class BaseEntity<KeyT>
    {
        public KeyT Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool Deleted { get; set; }
    }
}
