using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class ProductSpecification
    {
        public string Id { get; set; }
        public int ProductId { get; set; }
        public List<SpecificationGroup> SpecificationGroups { get; set; }
    }

    public class SpecificationGroup
    {
        public string GroupName { get; set; }
        public List<SpecAttribute> Attributes { get; set; }
    }

    public class SpecAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
