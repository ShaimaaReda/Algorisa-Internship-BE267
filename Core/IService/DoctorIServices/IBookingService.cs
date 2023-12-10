using Core.Domain.Model;
using Core.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IService.DoctorIServices
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAll(Guid doctorId);
    }
}
