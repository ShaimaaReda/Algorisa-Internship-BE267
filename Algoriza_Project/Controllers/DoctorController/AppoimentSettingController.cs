using Core.Domain.Model;
using Core.IService.DoctorIServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Service.DoctorServices;

namespace Algoriza_Project.Controllers.DoctorController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppoimentSettingController : ControllerBase
    {
        private readonly IAppoimentSetting _appoimentSetting;
        private readonly IScheduleService _scheduleService;
        public AppoimentSettingController(IAppoimentSetting appoimentSetting, IScheduleService scheduleService)
        {
            _appoimentSetting = appoimentSetting;
            _scheduleService = scheduleService;
        }

        [HttpPost(nameof(AddAppointment))]
        public async Task<IActionResult> AddAppointment([FromBody] AppoinmentModel appointmentModel)
        {
            if (appointmentModel != null)
            {
                var appointment = new Appointment()
                {
                    Price = appointmentModel.Price,
                    DoctorId = appointmentModel.DoctorId.ToString(),
                };

                await _appoimentSetting.Insert(appointment);

                foreach (var dayScheduleModel in appointmentModel.Schedule)
                {
                    foreach (var time in dayScheduleModel.Times)
                    {
                        _scheduleService.Insert(new DaySchedule
                        {
                            AppointmentId= appointment.Id,
                            Day = dayScheduleModel.Day,
                            Times = time
                        });
                    }
                }
                
               return Ok("Created Successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateAppoiment(Appointment appointment)
        {
            if (appointment != null)
            {
                _appoimentSetting.Update(appointment);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult DeleteAppoiment(Appointment appointment)
        {
            if (appointment != null)
            {

                _appoimentSetting.Delete(appointment);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
