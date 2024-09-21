using HotCatCafe.Common.EmailHelpers;
using HotCatCafe.Common.ProductHelper;
using HotCatCafe.IOC.DependencyResolves;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Configuration.GetConnectionString("OguzConnection");

// Dependency Injection Services
//AddDbContext
//builder.Services.AddHotCatCafeDb();
builder.Services.AddHotCatCafeDb(builder.Configuration);

//Emaill Senden Initialize
EmailSender.Initialize(builder.Configuration);

//Send Product Stock Mail Initialize
ProductOrderMail.Initialize(builder.Configuration);

//Repository Services
builder.Services.AddRepositoryService();

//User Manager Services
builder.Services.AddIdentityService();

//session
builder.Services.AddSession(x =>
{
    x.Cookie.Name = "HotCatCafe_Table_Session";
    x.IdleTimeout = TimeSpan.FromMinutes(5);
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

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

//session
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("CorsPolicy");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
   );

    app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}");

});


app.Run();

