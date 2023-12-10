using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class CouponModel
    {
        public Guid? Id { get; set; }
        public string DiscountCode { get; set; }
        public string Discount { get; set; }//Percentage or value
        public int Value { get; set; }
        public bool IsActive { get; set; }
    }
}
