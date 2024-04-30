using Banking_Project.BusinessLayer.Abstract;
using Banking_Project.BusinessLayer.Concrete;
using Banking_Project.DataAccessLayer.Abstract;
using Banking_Project.DataAccessLayer.Concrete;
using Banking_Project.DataAccessLayer.EntityFramework;
using Banking_Project.EntityLayer.Concrete;
using Banking_Project.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddScoped<ICustomerAccountProcessDal,EfCustomerAccountProcessDal>();
builder.Services.AddScoped<ICustomerAccountProcessService,CustomerAccountProcessManager>();

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
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
