using CrudMVCByKING.Interfaces;
using CrudMVCByKING.Repositories;
using Microsoft.EntityFrameworkCore;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Services.Repository;
using CrudMVCByKING.Helpers;
using CrudMVCByKING.Services;
using CrudMVCByKING.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

using NToastNotify;
using CrudMVCByKING.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IRepositoryService<AboutDto>, AboutRepository>();
builder.Services.AddScoped<IRepositoryService<ContactDto>, ContactRepository>();
builder.Services.AddScoped<FaqRepository>();
builder.Services.AddScoped<LessonExpRepository>();
builder.Services.AddScoped< IRepositoryService < CommentsDto > ,CommentsRepository >();
builder.Services.AddScoped<IRepositoryService<ResultDto>, ResultRepository>();
builder.Services.AddScoped<ICourse, CourseRepository>();
builder.Services.AddScoped<IRepositoryService<TeachersDto>, TeachersRepository>();
builder.Services.AddScoped<IUsers, UserRepository>();
builder.Services.AddScoped<ILessons, LessonsRepository>();
builder.Services.AddScoped<IHomeworks, HomeworkRepository>();
builder.Services.AddScoped<IUserCourse, UserCourseRepository>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<UsersDbContext>();

builder.Services.AddDbContext<UsersDbContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("connection")));
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       .AddCookie();

builder.Services.AddRazorPages().AddNToastNotifyNoty(new NotyOptions
{
    ProgressBar = true,
    Timeout = 5000
});



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

app.UseAuthentication();
app.UseNToastNotify();

app.MapRazorPages();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
