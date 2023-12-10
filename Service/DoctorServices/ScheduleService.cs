using Core.Domain.Model;
using Core.IRepository;
using Core.IService.DoctorIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DoctorServices
{
    public class ScheduleService: IScheduleService
    {
        private readonly IRepository<DaySchedule> _ScheduleRepository;
        public ScheduleService(IRepository<DaySchedule> ScheduleRepository)
        {
            _ScheduleRepository = ScheduleRepository;
        }

         public async Task Insert(DaySchedule Schedule)
         {
                try
                {
                    if (Schedule != null)
                    {
                        await _ScheduleRepository.AddAsync(Schedule);
                        await _ScheduleRepository.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
         }
    }

}
