using Microsoft.EntityFrameworkCore;
using MunicipalityManagementSystem.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// Add DbContext with SQL Server

builder.Services.AddDbContext<MunicipalityManagementSystemDbContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Seed the database

using (var scope = app.Services.CreateScope())

{

    var services = scope.ServiceProvider;

    try

    {

        var context = services.GetRequiredService<MunicipalityManagementSystemDbContext>();

        context.Database.EnsureCreated(); // Creates the database if it doesn't exist

    }

    catch (Exception ex)

    {

        var logger = services.GetRequiredService<ILogger<Program>>();

        logger.LogError(ex, "An error occurred while seeding the database.");

    }

}

// Configure the HTTP request pipeline.

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

    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

