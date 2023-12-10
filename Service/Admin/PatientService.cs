using Core.Domain.Model;
using Core.IRepository;
using Core.IService.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<User> _UserRepository;
        public PatientService(IRepository<User> UserRepository)
        {
            _UserRepository = UserRepository;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                var obj = await _UserRepository.GetAllWhereAsync(a=>a.UserType=="Patient");
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetById(string Id)
        {
            try
            {
                var obj = await _UserRepository.GetByIdAsync(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int NumOfPations()
        {
            try
            {
                return _UserRepository.NumOfPations();

            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
