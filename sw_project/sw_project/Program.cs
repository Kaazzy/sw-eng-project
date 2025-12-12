using Microsoft.EntityFrameworkCore; // Required for UseSqlServer()
using sw_project.Data; // Required for FinanceAppContext
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<FinanceAppContext>(options =>
{
  
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Identity using existing DbContext for user tables
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
    .AddEntityFrameworkStores<FinanceAppContext>();

builder.Services.AddScoped<sw_project.Data.services.IExpensesService, sw_project.Data.services.ExpensesService>();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Identity UI endpoints (if scaffolded)
app.MapRazorPages();

app.Run();
