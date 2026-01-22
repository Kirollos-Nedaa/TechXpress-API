using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class ProductImage
    {
        public int ImageID { get; set; }
        public int ProductID { get; set; }
        public string ImageUrl { get; set; }
        public string? AltText { get; set; }
        public int SortOrder { get; set; }

        public Product Product { get; set; }
    }
}
