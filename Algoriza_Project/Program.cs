using Algoriza_Project.DataBase;
using Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Core.IService.Admin;
using Algoriza_Project.Repository;
using Service.Admin;
using Core.IService.DoctorIServices;
using Service.DoctorServices;
using Microsoft.AspNetCore.Identity;
using Core.IService;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DB_ConStr")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<SignInManager<User>>();

builder.Services.AddScoped(typeof(Core.IRepository.IRepository<User>), typeof(Repository<User>));
builder.Services.AddScoped(typeof(Core.IRepository.IRepository<Doctor>), typeof(Repository<Doctor>));
builder.Services.AddScoped(typeof(Core.IRepository.IRepository<Appointment>), typeof(Repository<Appointment>));
builder.Services.AddScoped(typeof(Core.IRepository.IRepository<Checkup>), typeof(Repository<Checkup>));
builder.Services.AddScoped(typeof(Core.IRepository.IRepository<DiscountCoupon>), typeof(Repository<DiscountCoupon>));
builder.Services.AddScoped(typeof(Core.IRepository.IRepository<Booking>), typeof(Repository<Booking>));
builder.Services.AddScoped(typeof(Core.IRepository.IRepository<DaySchedule>), typeof(Repository<DaySchedule>));
builder.Services.AddScoped(typeof(Core.IRepository.IRepository<Specialization>), typeof(Repository<Specialization>));


builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<ICheckup, Checkup>();
builder.Services.AddScoped<IAppoimentSetting, AppoimentSetting>();
builder.Services.AddScoped<ISpecializeService, SpecializeService>();


//builder.Services.AddDefaultIdentity<Patient>(options => options.SignIn.RequireConfirmedAccount = true)
//        .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapSwagger().RequireAuthorization();


app.MapSwagger().RequireAuthorization();

app.Run();
