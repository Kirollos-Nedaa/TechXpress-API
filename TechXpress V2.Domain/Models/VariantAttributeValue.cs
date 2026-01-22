using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class VariantAttributeValue
    {
        public int VariantID { get; set; }
        public int ValueID { get; set; }

        public ProductVariant Variant { get; set; } = null!;
        public AttributeValue Value { get; set; } = null!;
    }
}
