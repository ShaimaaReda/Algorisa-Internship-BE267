using Core.Domain.Model;
using Core.IRepository;
using Core.IService.DoctorIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Service.DoctorServices
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _bookRepository;
        public BookingService(IRepository<Booking> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<Booking>> GetAll(Guid doctorId)
        {
            try
            {
                var obj = await _bookRepository.GetAllWhereAsync(b => b.DoctorId == doctorId);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
