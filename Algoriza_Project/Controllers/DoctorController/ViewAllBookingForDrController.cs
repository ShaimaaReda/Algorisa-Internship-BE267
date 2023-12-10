using Core.IService.Admin;
using Core.IService.DoctorIServices;
using Microsoft.AspNetCore.Mvc;
using Core.Domain.Model;
using Core.IService.DoctorIServices;
using Microsoft.AspNetCore.Http;
using Service.Admin;
using Core.Domain.Model;
using Nest;
using Time = Core.Domain.Model.Time;


namespace Algoriza_Project.Controllers.DoctorController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewAllBookingForDrController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public ViewAllBookingForDrController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet(nameof(GetAllBooking))]
        public async Task<IActionResult> GetAllBooking([FromQuery]Guid doctorId, int pageSize = 10, int pageNumber = 1)
        {
            var doctorBookings =await _bookingService.GetAll(doctorId);

            var paginatedBookings = doctorBookings
           .Skip((pageNumber - 1) * pageSize)
           .Take(pageSize)
           .ToList();
            
            if (doctorBookings == null)
            {
                return NotFound();
            }

            var bookingDTOs = paginatedBookings.Select(booking => new BookingOfDoctorModel
            {
                PatientName = booking.PatientName,
                Image = booking.Image,
                Age = CalculateAge(booking.DateOfBirth),
                Gender = booking.Gender,
                PhoneNumber = booking.Phone,
                Email = booking.Email,
                Appointment = new DaySchedule
                {
                    Day = booking.Appointment.Schedule.FirstOrDefault().Day,
                    Times =booking.Appointment.Schedule.FirstOrDefault().Times
                }
            }).ToList();

            return Ok(bookingDTOs);
        }

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
