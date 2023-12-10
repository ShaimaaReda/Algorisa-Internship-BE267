using Core.IRepository;
using Core.IService.Admin;
using Core.Domain.Model;
using Microsoft.AspNetCore.Identity;

namespace Service.Admin
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<Doctor> _UserRepository;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DoctorService(IRepository<Doctor> UserRepository, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _UserRepository = UserRepository;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            try
            {
                var obj = await _UserRepository.GetAllAsync();
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
        public async Task<IEnumerable<Doctor>> GetAllInclude()
        {
            try
            {
                var obj = await _UserRepository.GetAllIncludesAsync(w => w.Specialize,a => a.Appointments);
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
        public async Task<Doctor> GetById(string Id)
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

        public async Task Insert(Doctor entity)
        {
            try
            {
                if (entity != null)
                {
                    await _UserRepository.AddAsync(entity);
                    await _UserRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(Doctor entity)
        {
            try
            {
                if (entity != null)
                {
                    var doctors = await _UserRepository.GetAllWhereAsync(w=>w.Id==entity.Id);
                    var entityDoctor = doctors.FirstOrDefault();
                    entityDoctor.UserName = entity.UserName;
                    entityDoctor.Email = entity.Email;
                    entityDoctor.DateOfBirth = entity.DateOfBirth;
                    entityDoctor.PhoneNumber= entity.PhoneNumber;
                    entityDoctor.Gender= entity.Gender;
                    await _UserRepository.EditAsync(entityDoctor);
                    _UserRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task Delete(string id)
        {
            try
            {
                var doctors = await _UserRepository.GetAllWhereAsync(w => w.Id == id);
                var entityDoctor = doctors.FirstOrDefault();
                if (entityDoctor != null)
                {
                    await _UserRepository.DeleteAsync(id);
                    await _UserRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            };
        }
        public int NumOfDoctors()
        {
            try
            {
                return _UserRepository.NumOfDoctors();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Doctor> Top10Doctors()
        {
            try
            {
                var listofDr = _UserRepository.Top10Doctors();
                if (listofDr != null)
                {
                    return listofDr;
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

        public async Task<IdentityResult> CreateDoctorAsync(Doctor doctor,string password)
        {

            doctor.UserType = "Doctor";

            // Create the doctor user
            var result = await _userManager.CreateAsync(doctor,password);

            // Check if user creation was successful
            if (result.Succeeded)
            {
                // Add the user to the "doctor" role
                await _userManager.AddToRoleAsync(doctor, "Doctor");
            }

            return result;
        }
    }
}
