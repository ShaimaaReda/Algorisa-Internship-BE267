using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class DiscountCoupon
    {
        [Key]
        public Guid Id { get; set; }
        public string DiscountCode { get; set; }
        public int NumberOfRequests { get; set; }
        public DiscountType discount { get; set; }//Percentage or value
        public int Value { get; set; }
        public bool IsActive {  get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
