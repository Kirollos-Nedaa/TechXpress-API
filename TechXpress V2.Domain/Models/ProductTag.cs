using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class ProductTag
    {
        public int ProductID { get; set; }
        public int TagID { get; set; }

        public Product Product { get; set; }
        public Tag Tag { get; set; }
    }
}
