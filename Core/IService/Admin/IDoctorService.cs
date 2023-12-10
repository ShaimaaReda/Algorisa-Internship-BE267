using Core.Domain.Model;
using Microsoft.AspNetCore.Identity;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IService.Admin
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAll();
        Task<IEnumerable<Doctor>> GetAllInclude();
        Task<Doctor> GetById(string Id);
        Task Insert(Doctor entity);
        Task Update(Doctor entity);
        Task Delete(string Id);
        IEnumerable<Doctor> Top10Doctors();
        int NumOfDoctors();
        Task<IdentityResult> CreateDoctorAsync(Doctor doctor,string password);
    }
}
