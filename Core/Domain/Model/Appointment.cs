using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string DoctorId { get; set; }
        // public ICollection<Doctor> Doctors { get; set; }
        public decimal Price { get; set; }
        //public Days Day { get; set; }
        //public Time Time { get; set; }
        public ICollection<DaySchedule> Schedule { get; set; }
    }
}

