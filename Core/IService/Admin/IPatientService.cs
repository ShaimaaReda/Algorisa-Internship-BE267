using Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IService.Admin
{
    public interface IPatientService
    {

        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(string Id);
        int NumOfPations();
    }
}
