using Core.Domain.Model;
using Core.IRepository;
using Core.IService;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SpecializeService : ISpecializeService
    {
        private readonly IRepository<Specialization> _Repository;

        public SpecializeService(IRepository<Specialization> Repository)
        {
            _Repository = Repository;
        }

        public IEnumerable<Specialization> GetTop5Specialization()
        {
            try
            {
                var listofSpecialize = _Repository.Top5Specializations();
                if (listofSpecialize != null)
                {
                    return listofSpecialize;
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
    }
}
