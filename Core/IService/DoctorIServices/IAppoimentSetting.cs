using Core.Domain.Model;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IService.DoctorIServices
{
    public interface IAppoimentSetting
    {
        Task Insert(Appointment entity);
        Task Update(Appointment entity); //Update on time
        Task Delete(Appointment entity);
    }
}
