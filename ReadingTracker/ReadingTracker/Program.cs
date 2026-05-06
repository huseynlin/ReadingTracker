using Microsoft.AspNetCore.Authentication.Cookies;
using ReadingTracker.Services;

var builder = WebApplication.CreateBuilder(args);

// JSON Servisimizi proqrama qeydiyyatdan keçiririk
builder.Services.AddSingleton<JsonDataService>();

// Cookie (Sistemə Giriş) tənzimləmələri
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Səlahiyyətsiz giriş edəni bura atır
        options.ExpireTimeSpan = TimeSpan.FromDays(7); // Girişin qüvvədə qalma müddəti
    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Təhlükəsizlik qaydası: Autentifikasiya həmişə Avtorizasiyadan əvvəl gəlir
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}"); // İlk açılan səhifə Login olsun

app.Run();