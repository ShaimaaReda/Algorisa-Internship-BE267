using Bogus.DataSets;
using Core.Domain.Model;
using Core.IService;
using Core.IService.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Service;
using Service.Admin;

namespace Algoriza_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Dashboard : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly ISpecializeService _specializeService;
        public Dashboard(IDoctorService doctorService, ISpecializeService specializeService, IPatientService patientService)
        {
            _doctorService = doctorService;
            _patientService = patientService;
            _specializeService = specializeService;
        }
        [HttpGet(nameof(NumberOfPatient))]
        public IActionResult NumberOfPatient()
        {
            var count = _patientService.NumOfPations();
            if (count != null)
                return Ok(count);
            else
                return BadRequest("Something went wrong");
        }
        
        [HttpGet(nameof(GetNumOfDoctors))]
        public IActionResult GetNumOfDoctors()
        {
            var NumberOfDr = _doctorService.NumOfDoctors();
            if (NumberOfDr != null)
                return Ok(NumberOfDr);
            else
                return BadRequest("Something went wrong");
        }

        [HttpGet(nameof(TOP10Doctor))]
        public async Task<IActionResult> TOP10Doctor()
        {
            var obj = await _doctorService.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj.Select(w => new GeneralModel
            {
                Id = w.Id,
                UserName = w.UserName,
                Email = w.Email,
                DateOfBirth = w.DateOfBirth,
                SpecializeId = w.SpecializeId,
                PhoneNumber = w.PhoneNumber,
                Gender = w.Gender.ToString()

            }).ToList());
        }
        [HttpGet(nameof(TOP5Specialization))]
        public IActionResult TOP5Specialization()
        {
            var obj =  _specializeService.GetTop5Specialization();
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj.Select(w => new SpecializeModel
            {
                Name = w.Name,
                Number_Of_Request = w.NumberOfRequests,

            }).ToList());
        }


    }
}
