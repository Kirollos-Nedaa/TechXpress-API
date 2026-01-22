using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? DisplayName { get; set; }
        public string? SecondaryEmail { get; set; }

        // Navigation property
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<UserPaymentMethod> PaymentMethods { get; set; } = new List<UserPaymentMethod>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public Cart Cart { get; set; }
        public Wishlist Wishlist { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
    }
}
