using Core.Domain.Model;
using Core.IService.DoctorIServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Algoriza_Project.Controllers.DoctorController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmCheckUpController : ControllerBase
    {
        private readonly ICheckup _checkup;
        public ConfirmCheckUpController(ICheckup checkup)
        {
            _checkup = checkup;
        }
        [HttpPut]
        public IActionResult ConfirmCheckUp(string id)
        {
            if(id != null)
            {
                _checkup.CheckUpAsync(id);
                return Ok("Confirm Successfully");
            }   
            else
                return BadRequest("Something went wrong");
        }
    }
}
