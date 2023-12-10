using Core.Domain.Model;
using Core.IRepository;
using Core.IService;
using Core.IService.DoctorIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.DoctorServices
{
    public class AppoimentSetting : IAppoimentSetting
    {
        private readonly IRepository<Appointment> _AppRepository;
        private readonly IRepository<Booking> _BookingRepository;
        public AppoimentSetting(IRepository<Appointment> AppRepository, 
                                IRepository<Booking> BookingRepository)
        {
            _AppRepository = AppRepository;
            _BookingRepository = BookingRepository;
        }
        public async Task Insert(Appointment appointment)
        {
            try
            {
                if (appointment != null)
                {
                    await _AppRepository.AddAsync(appointment);
                    await _AppRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(Appointment appointment)
        {
            try
            {
                var item = _BookingRepository.GetAllWhereAsync(a => a.AppointmentId == appointment.Id);
                if (item == null)
                {
                    await _AppRepository.EditAsync(appointment);
                    await _AppRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(Appointment appointment)
        {
            try
            {
                var item = _BookingRepository.GetAllWhereAsync(a => a.AppointmentId == appointment.Id);
                if (item == null)
                {
                    await _AppRepository.DeleteAsync(appointment.Id.ToString());
                    await _AppRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

