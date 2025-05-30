using Microsoft.AspNetCore.Identity;
using SpeechToTextProject.BusinessLayer.Abstract;
using SpeechToTextProject.BusinessLayer.Concrete;
using SpeechToTextProject.DataAccessLayer.Context;
using SpeechToTextProject.EntityLayer.Concrete;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient();

builder.Services.AddDbContext<ApiContext>();
builder.Services.AddIdentity<AudioUser, AudioRole>().AddEntityFrameworkStores<ApiContext>();

builder.Services.AddControllersWithViews();



var app = builder.Build();

//app.UseStaticFiles();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
