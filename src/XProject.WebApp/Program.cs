using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using XProject.Core;
using XProject.WebApp.Data;
using XProject.Repositories;
using AutoMapper;
using XProject.Repositories.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 5;
}).AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<DataInitRepository>();
builder.Services.AddScoped<LossesRepository>();
builder.Services.AddScoped<UserRoleRepository>();
builder.Services.AddScoped<UserManager<AppUser>>();
builder.Services.AddScoped<RoleManager<IdentityRole>>();
/*
var mapperConfig = new MapperConfiguration(c => {
    c.AddProfile<AppMapperProfile>();
});
builder.Services.AddSingleton<IMapper>(m => mapperConfig.CreateMapper());
*/

// Змінено
// Додано рефренс на пакет AutoMapper DependencyInjection / Не зрозумів Антоніну! Потім згадав
builder.Services.AddAutoMapper(typeof(AppMapperProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
