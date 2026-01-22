using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class RelatedProduct
    {
        public int ProductID { get; set; }
        public int RelatedProductID { get; set; }

        public Product Product { get; set; }
        public Product Related { get; set; }
    }
}
