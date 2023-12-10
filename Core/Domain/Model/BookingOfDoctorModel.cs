using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class BookingOfDoctorModel
    {
        public Guid Id { get; set; }
        public string PatientName { get; set; }
        public Gender Gender { get; set;}
        public int Age { get; set;}
        public string Image { get; set;}
        public string PhoneNumber { get; set;}
        public string Email { get; set;}
        public DaySchedule Appointment { get; set;}
        public DiscountCoupon DiscountCoupon { get; set;}
    }
}
