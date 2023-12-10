using Core.Domain.Model;
using Core.IRepository;
using Core.IService.Admin;
using Core.IService.PatientServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Service.PatientServices
{
    public class PatientBookingService : IPatientBookingService
    {
        private readonly IRepository<Booking> _bookRepository;

        public PatientBookingService(IRepository<Booking> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> AddBooking(Booking entity)
        {
            try
            {
                if (entity != null)
                {
                    await _bookRepository.AddAsync(entity);
                    await _bookRepository.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}