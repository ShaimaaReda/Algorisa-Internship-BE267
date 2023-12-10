using Core.Domain.Model;
using Core.IService.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Algoriza_Project.Controllers.PatientController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchOnDrController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public SearchOnDrController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpGet(nameof(SearchOnDoctors))]
        public async Task<IActionResult> SearchOnDoctors()//get all dr
        {
            var obj = await _doctorService.GetAllInclude();
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj.Select(w => new GeneralModel
            {
                UserName = w.UserName,
                Email = w.Email,
                Specialize = w.Specialize.Name,
                PhoneNumber = w.PhoneNumber,
                Gender = w.Gender.ToString(),
                Schedule = w.Appointments.FirstOrDefault().Schedule,
                Price = w.Appointments.FirstOrDefault().Price

            }).ToList());
        }
    }
}
