using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public string Code { get; set; }
        public string DiscountType { get; set; }
        public decimal Amount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal MinPurchaseAmount { get; set; }
        public bool IsActive { get; set; }
    }
}
