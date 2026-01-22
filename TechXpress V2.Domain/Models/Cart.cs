using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public string? UserID { get; set; }
        public string SessionID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
