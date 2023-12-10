using Core.Domain.Model;
using Core.IRepository;
using Core.IService.DoctorIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Service.DoctorServices
{
    public class Checkup :ICheckup
    {
        private readonly IRepository<Booking> _repository;
        public Checkup(IRepository<Booking> repository) => _repository = repository;

        public async Task<bool> CheckUpAsync(string id)
        {
            var request = await _repository.GetByIdAsync(id);//get booking where this id 
            if(request!=null) //if exist
            {
                request.status = RequestType.Completed;
                return true;
            }
            else
            { return false; }
        }
    }
}
