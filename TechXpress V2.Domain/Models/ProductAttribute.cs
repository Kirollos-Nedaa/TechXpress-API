using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class ProductAttribute
    {
        public int AttributeID { get; set; }
        public string Name { get; set; }
        public ICollection<AttributeValue> Values { get; set; } = new List<AttributeValue>();
    }
}
