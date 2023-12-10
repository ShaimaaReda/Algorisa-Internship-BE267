using Algoriza_Project.DataBase;
using Azure;
using Core.Domain.Model;
using Core.IRepository;
using MathNet.Numerics.Statistics.Mcmc;
using Microsoft.EntityFrameworkCore;
using Nest;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Algoriza_Project.Repository
{
    public class Repository<T> : Core.IRepository.IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> entities;

        public Repository(ApplicationDbContext _context)
        {
            context = _context;
            entities = context.Set<T>();
        }
        public async Task AddAsync(T Model)
        {
            if (Model == null)
            {
                throw new ArgumentNullException("Model");
            }
            await entities.AddAsync(Model);
            await SaveChanges();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await entities.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await SaveChanges();
        }
        public async Task EditAsync(T Model)
        {
            if (Model == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(Model);
            await SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return (IEnumerable<T>)entities.Where(predicate).AsAsyncEnumerable();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return (IEnumerable<T>)entities.AsAsyncEnumerable();
        }

        public async Task<IEnumerable<T>> GetAllIncludesAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = entities.AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            foreach (var include in includes.Skip(1)) // Skip the first include, as it's already included
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await entities.FindAsync(id);
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await entities.FindAsync(id);
        }
        public async Task SaveChanges()
        {
            context.SaveChanges();
        }

        /// //////////////////////////////////////////////////////////////////////


        public IEnumerable<T> Top5Specializations()
        {
            return entities.Take(5).ToList();
        }

        public IEnumerable<T> Top10Doctors()
        {
            return entities.Take(10).AsEnumerable();

        }

        public int NumOfRequests()//Booking table
        {
            return entities.ToList().Count;
        }

        public int NumOfPations()// User -> patient
        {
            return entities.ToList().Count;
        }

        public int NumOfDoctors() //User -> doctor
        {
            return entities.ToList().Count;
        }
        ////////////////////


    }
}
