using CampingApp.Data;
using CampingApp.Services;
using CampingApp.Services.Contract;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CampingConnectionString")
	?? throw new InvalidOperationException("Connection CampingDB not found");

//builder.Services.AddDbContext<CampingDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<CampingDbContext>(options => options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<IEmployeeManagementService, EmployeeManagementService>();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjMzMjM2NEAzMjMxMmUzMDJlMzBPR0V2dlNjbG5BN0RaSm53ckJObkswRHFsNEZpVkkrT3Q3SmF4MjlCZVdRPQ==;Mgo+DSMBaFt+QHJqVk1mQ1BHaV1CX2BZf1N8RWFTf1xgBShNYlxTR3ZZQltiSX5RdkdrWH1e;Mgo+DSMBMAY9C3t2VFhiQlJPcEBDXnxLflF1VWJZdV5yflVEcC0sT3RfQF5jT35Vd0VjW39ceHdVRg==;Mgo+DSMBPh8sVXJ1S0R+X1pCaV5BQmFJfFBmRGNTf1x6dFdWESFaRnZdQV1lSXhSdkVhWX1WdH1V;MjMzMjM2OEAzMjMxMmUzMDJlMzBBcVppUnhXb0g4dGFWV1FsbVpTNkJKWFljUmJqc21yUUpDb0Z2SDZaRkZzPQ==;NRAiBiAaIQQuGjN/V0d+Xk9HfVldXGBWfFN0RnNYf1Rwdl9GYkwgOX1dQl9gSXhTcERjWX1ecnxcRGA=;ORg4AjUWIQA/Gnt2VFhiQlJPcEBDXnxLflF1VWJZdV5yflVEcC0sT3RfQF5jT35Vd0VjW39ceXRcRg==;MjMzMjM3MUAzMjMxMmUzMDJlMzBRcGNBN1RIVWZuQWFGc21EdzF1RXErLzZkSWJVVkhIWkk5OWcyQmpoNTAwPQ==;MjMzMjM3MkAzMjMxMmUzMDJlMzBnK2czMDBoTDBzajBDVXpTajNpNW4vcVJZaDI5RkFKamJVS0ZpUVFLRXZjPQ==;MjMzMjM3M0AzMjMxMmUzMDJlMzBmOWo1VW1wZEhZZXFaMElNUjdHMmN3R01WRVRISW5IT1NGUlBMYWNWelNRPQ==;MjMzMjM3NEAzMjMxMmUzMDJlMzBhWkVVK2w3eSs1SmhZc1d2Qjdld0dGMkRnV2NSWkdKWmNtQW9Wb2pTSDlFPQ==;MjMzMjM3NUAzMjMxMmUzMDJlMzBPR0V2dlNjbG5BN0RaSm53ckJObkswRHFsNEZpVkkrT3Q3SmF4MjlCZVdRPQ==");

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
