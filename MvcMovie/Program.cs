using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using Microsoft.AspNetCore.Identity;
using MvcMovie.Models;
using MvcMovie.Models.Process;
using Microsoft.AspNetCore.Identity.UI.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptions();
var mailSettings = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(mailSettings);
 builder.Services.AddTransient<IEmailSender, SendMailService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
 options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
 ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

builder.Services.AddRazorPages();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
.AddEntityFrameworkStores<ApplicationDbContext>();

// Cấu hình Razor Pages + MVC
builder.Services.AddControllersWithViews();
builder.Services.Configure<IdentityOptions>(options =>
    {
        //default lockout setting
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;

        //config password
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = false;

        //config login
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;

        //config user
        options.User.RequireUniqueEmail = true;
    });
builder.Services.ConfigureApplicationCookie(options =>
{
    //options.Cookie.HttpOnly = true;
    //chi gui cookie qua https
    //options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    //giam thieu rui ro csrf
    //options.Cookie.SameSite = SameSiteMode.Lax;
    //options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Idenity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
    //options.SlidingExpiration = true;

});




builder.Services.AddTransient<EmployeeSeeder>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seeder = services.GetRequiredService<EmployeeSeeder>();
    seeder.SeedEmployees(1000);

}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication(); // 👈 BẮT BUỘC để login hoạt động

app.UseAuthorization();

app.MapStaticAssets();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages(); // 👈 BẮT BUỘC để các Razor Pages như Login/Register chạy được

app.Run();
