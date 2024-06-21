using Auction.MVC.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Auction.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews(options =>
        {
           // options.Filters.Add<GlobalExceptionFilter>();
        });

        builder.Services.AddApplication();
        builder.Services.AddDataAccessLayer(builder.Configuration);

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
		{
			options.LoginPath = "/Auth/Login";
			options.AccessDeniedPath = "/Auth/Registration"; 
		});


        builder.Logging. Services.AddHttpContextAccessor();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}");

        app.Run();
    }
}