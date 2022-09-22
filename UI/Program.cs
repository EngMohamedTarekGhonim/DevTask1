using Application.DepartmentService;
using Application.Infrastracture.Helper;
using Core.Interface;
using Core.Interface.BaseRepository;
using Infrastracture.AppDbContext;
using Infrastracture.Repository;
using Infrastracture.Repository.Base;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Reflection;
using Hangfire;
using Application.ScheduleService;
using Application.MailingService;
using Core.Infrastructure.Dtos;
using Application.UploadFileService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDataContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// interfaces
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IReminderRepository, ReminderRepository>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IScheduleService, ScheduleService>();
builder.Services.AddTransient<IReminderService, ReminderService>();
builder.Services.AddTransient<IMailingService, MailingService>();
builder.Services.AddTransient<IUploadFileService, UploadFileService>();

// auto mapper
builder.Services.AddAutoMapper(typeof(MappingProfiles));
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// for hangfire
builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("Default")));
// for mail
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseHangfireDashboard("/dash"); // hangfire dashboard link


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Department}/{action=Index}/{id?}");

app.Run();
