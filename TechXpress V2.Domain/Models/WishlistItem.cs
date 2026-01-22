using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class WishlistItem
    {
        public int WishlistItemID { get; set; }
        public int WishlistID { get; set; }
        public int VariantID { get; set; }
        public DateTime AddedAt { get; set; }

        // Navigation properties
        public Wishlist Wishlist { get; set; }
        public ProductVariant Variant { get; set; }
    }
}
