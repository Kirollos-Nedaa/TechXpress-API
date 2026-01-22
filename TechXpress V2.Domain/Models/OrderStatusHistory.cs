using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class OrderStatusHistory
    {
        public int HistoryID { get; set; }
        public int OrderID { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public Order Order { get; set; }
    }
}
