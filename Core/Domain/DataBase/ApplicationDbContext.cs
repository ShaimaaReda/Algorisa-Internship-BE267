using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using Core.Domain.Model;

namespace Algoriza_Project.DataBase
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
                base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne()
                .HasForeignKey<Doctor>(d => d.UserId);
        }


        public DbSet<Doctor> Doctors { get; set; }
        //public DbSet<Patient> Patients { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Booking> Bookings { get; set; }



        internal Task<T> SingleOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
