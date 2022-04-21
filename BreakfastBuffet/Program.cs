using BreakfastBuffet.Data;
using BreakfastBuffet.Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<MyDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ReceptionOnly",
        policyBuilder => policyBuilder
        .RequireClaim("IsReceptionist"));

    options.AddPolicy("RestaurantOnly",
        policyBuilder => policyBuilder
        .RequireClaim("IsWaiter"));
});

builder.Services.AddRazorPages();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
    if (userManager != null)
        SeedData.SeedUsers(userManager);
    else throw new Exception("Unable to get UserManager!");
}
app.MapHub<KitchenHub>("/kitchenHub");

app.Run();
