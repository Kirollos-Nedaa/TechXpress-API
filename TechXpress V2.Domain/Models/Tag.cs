using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }
}
