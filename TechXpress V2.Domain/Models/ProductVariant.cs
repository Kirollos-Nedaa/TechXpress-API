using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class ProductVariant
    {
        public int VariantID { get; set; }
        public int ProductID { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public int StockQuantity { get; set; }
        public string? PrimaryImageURL { get; set; }

        public Product Product { get; set; }
        public ICollection<VariantAttributeValue> VariantAttributes { get; set; } = new List<VariantAttributeValue>();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();
    }
}
