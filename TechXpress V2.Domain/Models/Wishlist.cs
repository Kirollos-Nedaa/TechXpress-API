using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class Wishlist
    {
        public int WishlistID { get; set; }
        public string UserID { get; set; }

        // Navigation properties
        public ApplicationUser User { get; set; }
        public ICollection<WishlistItem> Items { get; set; } = new List<WishlistItem>();
    }
}
