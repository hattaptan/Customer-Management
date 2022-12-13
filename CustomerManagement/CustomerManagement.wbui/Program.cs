using CustomerManagement.Business.Manager;
using CustomerManagement.Business.Service;
using CustomerManagement.DataAccess.Abstract;
using CustomerManagement.DataAccess.Concrete;
using CustomerManagement.DataAccess.Context;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region DataAccesLayer Injection
builder.Services.AddScoped<ICustomerDal, CustomerDal>();
builder.Services.AddScoped<IUserDal, UserDal>();
#endregion

builder.Services.AddDbContext<CustomerManagementContext>();

#region BusinessLayer Injection
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<IUserService, UserManager>();
#endregion

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => false; // consent required
    options.MinimumSameSitePolicy = SameSiteMode.None;

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/Index";
                    options.LogoutPath = "/Login/Logout/";
                    //options.ReturnUrlParameter = "";
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
app.UseAuthorization();
 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
