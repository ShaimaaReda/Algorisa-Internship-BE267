using Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class Booking
    {
        public Guid Id { get; set; }
        public string PatientName { get; set; }
        public string Image { get; set; }//new
        public DateTime DateOfBirth { get; set; }//new
        public Gender Gender { get; set; }//new
        public string Phone { get; set; }//new
        public string Email { get; set; }//new
        public decimal Price {  get; set; }
        public decimal FinalPrice { get; set; }
        public Guid AppointmentId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid DiscountId { get; set; }
        public RequestType status { get; set; }
        public Days Day { get; set; }

        public Doctor Doctor { get; set; }
        public DiscountCoupon DiscountCoupon { get; set; }
        public Appointment Appointment { get; set; }
        
    }
}
