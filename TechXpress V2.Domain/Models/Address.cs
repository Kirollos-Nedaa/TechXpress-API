using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string UserID { get; set; }
        public string AddressType { get; set; }
        public bool IsDefault { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Navigation property
        public ApplicationUser User { get; set; }
    }
}
