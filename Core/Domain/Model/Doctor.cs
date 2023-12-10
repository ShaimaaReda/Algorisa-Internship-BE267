using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class Doctor : User
    {

        public int SpecializeId { get; set; }
        public Specialization Specialize { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
