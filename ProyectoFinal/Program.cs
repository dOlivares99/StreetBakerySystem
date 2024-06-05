using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using Microsoft.AspNetCore.Identity;
using ProyectoFinal.Settigs;
using SendGrid.Extensions.DependencyInjection;
using ProyectoFinal.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using ProyectoFinal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

//Ajustes de verification de email 
builder.Services.Configure<SendGridSettings>(builder.Configuration.GetSection("SendGridSettings"));
builder.Services.AddSendGrid(options => { options.ApiKey = builder.Configuration.GetSection("SendGridSettings").GetValue<string>("ApiKey"); });
builder.Services.AddScoped<IEmailSender, EmailSenderService>();


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

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=Index}/{id?}");

app.Run();
