using System;
using System.Collections.Generic;

#nullable disable

namespace BookEccommerce_Admin.Models
{
    public partial class Checkout
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public string Username { get; set; }
        public int? CartId { get; set; }
        public int? ShippingfeeId { get; set; }
        public int? PaymentId { get; set; }
        public double? Total { get; set; }
        public string Depositornumber { get; set; }
        public string Receivenember { get; set; }
        public string Quantity { get; set; }

        public virtual Account Account { get; set; }
        public virtual PaymentMethod Payment { get; set; }
        public virtual ShippingFee Shippingfee { get; set; }
    }
}
