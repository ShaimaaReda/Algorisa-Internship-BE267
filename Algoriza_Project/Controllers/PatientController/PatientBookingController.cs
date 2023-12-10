//using Algoriza_Project.Areas.Identity.Pages.Account;
//using Core.Domain.Model;
//using Core.IService.Admin;
//using Core.IService.PatientServices;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Algoriza_Project.Controllers.PatientController
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PatientBookingController : ControllerBase
//    {
//        private readonly IPatientBookingService _patientBooking;

//        public PatientBookingController(IPatientBookingService patientBooking)
//        {
//            _patientBooking = patientBooking;
//        }
//        [HttpPost]
//        public IActionResult CreateBooking(PatientBookingModel Book)
//        {
//            if (Book != null)
//            {
//                var obj = _patientBooking.
//               if ()
               

//                return Ok("Created Successfully");
//            }
//            else
//            {
//                return BadRequest("Somethingwent wrong");
//            }
//        }

//    }

//}
