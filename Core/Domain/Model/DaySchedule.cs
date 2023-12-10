using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class DaySchedule
    {
        public Guid Id { get; set; }
        public Days Day { get; set; }
        public Guid AppointmentId { get; set; }
        public Time Times { get; set; }
    }
}
