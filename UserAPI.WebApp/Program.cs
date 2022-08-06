using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserAPI.CORE.Entities;
using UserAPI.Infrastructure;
using UserAPI.Infrastructure.Data;
using UserAPI.Infrastructure.Data.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
var connectionString = builder.Configuration.GetConnectionString("IdentityConnection");
builder.Services.AddDbContext<WebAppContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddInfrastructure();


builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<WebAppContext>()
                .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Home/Login";
    options.LogoutPath = $"/Home/Logout";
});


var app = builder.Build();
CreateAndSeedDatabase(app);
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
app.UseAuthorization();
app.UseAuthentication();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default",
        pattern: "{controller=Home}/{action=Login}/{id?}");
    endpoints.MapRazorPages();
});




app.Run();


static void CreateAndSeedDatabase(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        
        var roleManager  = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        var userManager = services.GetRequiredService<UserManager<User>>();
        try
        {
            var aspnetRunContext = services.GetRequiredService<WebAppContext>();
            DefaultRoles.SeedAsync(roleManager).Wait();
            DeafultFeature.SeedFeaturesAsync(aspnetRunContext);
            DefaultBrand.SeedBrandAsync(aspnetRunContext).Wait();
            DefaultUsers.SeedAdminAsync(aspnetRunContext,userManager, roleManager).Wait();
            DefaultUsers.SeedCustomerAsync(aspnetRunContext,userManager, roleManager).Wait();
            DefaultUsers.SeedSuperAdminAsync(aspnetRunContext,userManager, roleManager).Wait();
            DefaultProduct.SeedProductAsync(aspnetRunContext).Wait();
           
        }
        catch (Exception exception)
        {
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogError(exception, "An error occured seeding the DB");
        }
    }
}
