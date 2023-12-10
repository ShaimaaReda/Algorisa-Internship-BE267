using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IService.DoctorIServices
{
    public interface ICheckup
    {
        Task<bool> CheckUpAsync(string id); 
    }
}
