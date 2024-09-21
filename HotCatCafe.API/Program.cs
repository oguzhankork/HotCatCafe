using HotCatCafe.Common.EmailHelpers;
using HotCatCafe.IOC.DependencyResolves;

var builder = WebApplication.CreateBuilder(args);

//API
builder.Services.AddControllers();

//ContextService
//builder.Configuration.GetConnectionString("OguzConnection");
builder.Services.AddHotCatCafeDb(builder.Configuration);

//Emaill Sender Initialize
EmailSender.Initialize(builder.Configuration);

//RepositoryService
builder.Services.AddRepositoryService();

builder.Services.AddIdentityService();

builder.Services.AddDistributedMemoryCache();
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

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
