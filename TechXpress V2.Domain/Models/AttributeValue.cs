using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class AttributeValue
    {
        public int ValueID { get; set; }
        public int AttributeID { get; set; }
        public string Value { get; set; }
        public string? ValueHex { get; set; }

        public ProductAttribute Attribute { get; set; }
        public ICollection<VariantAttributeValue> VariantLinks { get; set; } = new List<VariantAttributeValue>();
    }
}
