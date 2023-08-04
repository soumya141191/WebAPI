using Microsoft.EntityFrameworkCore;
using MVCTaskManager.Model;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(
      name: "OpenCORSPolicy",
      builder => {
          builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
      });
});
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();
app.UseCors("OpenCORSPolicy");

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
