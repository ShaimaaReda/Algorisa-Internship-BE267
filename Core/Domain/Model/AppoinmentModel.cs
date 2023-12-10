using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class AppoinmentModel
    {
        public Guid DoctorId { get; set; }
        public decimal Price { get; set; }
        public List<DayScheduleModel> Schedule { get; set; }
    }

    public class DayScheduleModel
    {
        public Days Day { get; set; }
        public List<Time> Times { get; set; }

    }
}
