using Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IService.PatientServices
{
    public interface IPatientBookingService
    {
        Task<bool> AddBooking(Booking entity);
    }
}
