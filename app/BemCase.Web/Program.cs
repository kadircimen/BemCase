using BemCase.Application;
using BemCase.Persistence;
using Core.CrossCuttingConcerns.Exceptions;
using Hangfire;
using BemCase.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistenceServices(builder.Configuration);
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddApplicationServiceRegistration();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHangfireDashboard();
app.CustomExceptionMiddleware();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();
DBPopulation.PrepPopulation(app);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
