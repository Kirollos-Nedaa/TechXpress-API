using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string Name { get; set; } = null!;
        public string LogoImageUrl { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
