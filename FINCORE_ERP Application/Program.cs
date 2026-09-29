using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("dbconn")
    ));

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserManagementService, UserManagementService>();
builder.Services.AddSession();

builder.Services.AddScoped<IVendorService,VendorService>();

builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();

//builder.Services
//    .AddAuthentication()
//    .AddCookie("GoogleCookie")
//    .AddGoogle(options =>
//    {
//        options.ClientId =
//            builder.Configuration["Authentication:Google:ClientId"]!;

//        options.ClientSecret =
//            builder.Configuration["Authentication:Google:ClientSecret"]!;

//        options.SignInScheme = "GoogleCookie";
//    });

var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authentication}/{action=LoginPage}/{id?}")
    .WithStaticAssets();


app.Run();
