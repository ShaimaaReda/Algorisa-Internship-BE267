using Core.Domain.Model;
using Core.IService.Admin;
using EnumsNET;
using Microsoft.AspNetCore.Mvc;
using Nest;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Algoriza_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminManagesDoctor : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public AdminManagesDoctor(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(string Id)
        {
            var obj = await _doctorService.GetById(Id);
            if (obj == null)
            {
                return NotFound();
            }

            var Model = new GeneralModel();
            {
                Model.Id = obj.Id;
                Model.UserName = obj.UserName;
                Model.Email = obj.Email;
                Model.PhoneNumber = obj.PhoneNumber;
                Model.DateOfBirth = obj.DateOfBirth;
                Model.SpecializeId = obj.SpecializeId;
                Model.Gender = obj.Gender.ToString();
            };
            return Ok(Model);
        }

        [HttpGet(nameof(GetAllDoctor))]
        public async Task<IActionResult> GetAllDoctor()
        {
            var obj = await _doctorService.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj.Select(w => new GeneralModel
            {
                Id =w.Id,
                UserName = w.UserName,
                Email = w.Email,
                DateOfBirth = w.DateOfBirth,
                SpecializeId = w.SpecializeId,
                PhoneNumber = w.PhoneNumber,
                Gender = w.Gender.ToString()

            }).ToList());
        }

        [HttpPost(nameof(CreateDoctor))]
        public async Task<IActionResult> CreateDoctor([FromBody] GeneralModel doctor)
        {
            if (doctor != null)
            {
                var Model = new Doctor
                {
                    UserType = "Doctor",
                    UserName = doctor.UserName,
                    Email = doctor.Email,
                    PhoneNumber = doctor.PhoneNumber,
                    Gender = (Gender)Enum.Parse(typeof(Gender), doctor.Gender),
                    DateOfBirth = doctor.DateOfBirth,
                    SpecializeId = doctor.SpecializeId,
                    PasswordHash = doctor.Password
                };
                var res = await _doctorService.CreateDoctorAsync(Model, doctor.Password);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }

        [HttpPut(nameof(UpdateDoctor))]
        public IActionResult UpdateDoctor(GeneralModel doctor)
        {
            if (doctor != null)
            {
                var Model = new Doctor()
                {
                    Id = doctor.Id,
                    UserName = doctor.UserName,
                    Email = doctor.Email,
                    PhoneNumber = doctor.PhoneNumber,
                    Gender = (Gender)Enum.Parse(typeof(Gender), doctor.Gender),
                    DateOfBirth = doctor.DateOfBirth,
                    SpecializeId = doctor.SpecializeId
                };
                _doctorService.Update(Model);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(string id)
        {
            if (id != null)
            {
                _doctorService.Delete(id);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        
    }
}
