using Core.Domain.Model;
using Core.IService.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Algoriza_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessAdminToPetients : ControllerBase
    {
        private readonly IPatientService _patientService;
        public AccessAdminToPetients(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet(nameof(GetPetientById))]
        public async Task<IActionResult> GetPetientById(string Id)
        {
            var obj = await _patientService.GetById(Id);
            if (obj == null)
            {
                return NotFound();
            }
            var Model = new GeneralModel();
            {
                Model.UserName = obj.UserName;
                Model.Email = obj.Email;
                Model.PhoneNumber = obj.PhoneNumber;
                Model.DateOfBirth = obj.DateOfBirth;
                Model.Gender = obj.Gender.ToString();
                
            };
            return Ok(Model);
           

        }

        [HttpGet(nameof(GetAllPetient))]
        public async Task<IActionResult> GetAllPetient()
        {
            var obj = await _patientService.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
           
                return Ok(obj.Select(w => new GeneralModel
                {
                    Id = w.Id.ToString(),
                    UserName = w.UserName,
                    Email = w.Email,
                    DateOfBirth = w.DateOfBirth,
                    PhoneNumber = w.PhoneNumber,
                    Gender = w.Gender.ToString()

                }).ToList());
            
        }


    }
}
