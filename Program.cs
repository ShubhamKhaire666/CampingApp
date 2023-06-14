using CampingApp.Data;
using CampingApp.Services;
using CampingApp.Services.Contract;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CampingConnectionString")
	?? throw new InvalidOperationException("Connection CampingDB not found");

//builder.Services.AddDbContext<CampingDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<CampingDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<CampingDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<IEmployeeManagementService, EmployeeManagementService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ISalesReportOrderService, SalesOrderReportService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<TokenProvider>();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHJqVEZrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRcQltiTX9SdUZiWn5ccnU=;Mgo+DSMBPh8sVXJ1S0R+XVFPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXhSckRiWnxfc3VWTmE=;ORg4AjUWIQA/Gnt2VFhiQlBEfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5Vd0FiWHxdcXdUQ2Rd;MjQxODI5NUAzMjMxMmUzMDJlMzBmeHBxOUc0NVcxTEdpdzdKbDJJTmNTZUJ4aXR6ZytaWmQ2SzBkanVRdWxnPQ==;MjQxODI5NkAzMjMxMmUzMDJlMzBnWmFvNzJhOVlINmY5T21NeTk5bnlqN0JZb1pkbGk4NUd4WU1kUWduZ2tvPQ==;NRAiBiAaIQQuGjN/V0d+Xk9FdlRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TcERnWH5dc3VWRGVbUA==;MjQxODI5OEAzMjMxMmUzMDJlMzBPdmVscWRUOTR1ZFN2cG9ZSnZ0VnY5bkg5eE9oQ0kzU2t0K2VnT1kxQzdJPQ==;MjQxODI5OUAzMjMxMmUzMDJlMzBGaEFYWkVxb1B0aUc4Tm9talRZaU5UbzE5QWJleGtZbVZkbWJFVFg4K1Z3PQ==;Mgo+DSMBMAY9C3t2VFhiQlBEfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5Vd0FiWHxdcXdWTmFd;MjQxODMwMUAzMjMxMmUzMDJlMzBWMG9QV05rRGdTVDhpNEZaZnllRzl0Y0tEQzFBNWVPSHNRMFYwbnQydXU4PQ==;MjQxODMwMkAzMjMxMmUzMDJlMzBRMzc5UWxpQzcyaEZncHBsZkJhOCtWYjkxZmhGUEMvS2VVWk1SdERuWmhZPQ==;MjQxODMwM0AzMjMxMmUzMDJlMzBPdmVscWRUOTR1ZFN2cG9ZSnZ0VnY5bkg5eE9oQ0kzU2t0K2VnT1kxQzdJPQ==");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
