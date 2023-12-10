using Core.Domain.Model;
using Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IService
{
    public interface ISpecializeService
    {
        //private readonly IRepository<Specialization> _Repository;
        IEnumerable<Specialization> GetTop5Specialization();
    }
}
