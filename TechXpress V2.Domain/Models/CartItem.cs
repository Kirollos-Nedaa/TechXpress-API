using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }
        public int CartID { get; set; }
        public int VariantID { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Cart Cart { get; set; }
        public ProductVariant Variant { get; set; }
    }
}
