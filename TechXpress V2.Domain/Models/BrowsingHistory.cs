using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class BrowsingHistory
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int VariantId { get; set; }
        public DateTime ViewedAt { get; set; }
    }
}
