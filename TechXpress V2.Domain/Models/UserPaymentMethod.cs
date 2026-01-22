using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress_V2.Domain.Models
{
    public class UserPaymentMethod
    {
        public int PaymentMethodID { get; set; }
        public string UserID { get; set; }
        public string ProviderToken { get; set; }
        public string LastFourDigits { get; set; }
        public string CardType { get; set; }
        public string ExpiryDate { get; set; }
        public bool IsDefault { get; set; }

        // Navigation property
        public ApplicationUser User { get; set; }
    }
}
