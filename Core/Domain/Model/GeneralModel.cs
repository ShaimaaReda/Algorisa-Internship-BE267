using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class GeneralModel
    {
        public string? Id { get; set; }
        public string UserName {  get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Image {  get; set; }
        public string Gender { get; set; }
        public string? Specialize { get; set; }
        public decimal? Price { get; set; }
        public ICollection<DaySchedule>? Schedule { get; set; }
        public int SpecializeId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Password { get; set; }
    }
}
