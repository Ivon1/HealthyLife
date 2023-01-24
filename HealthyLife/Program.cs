using HealthyLife.Data;
using HealthyLife.Models;
using HealthyLife.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

//builder.Services.AddTransient<IEmailSender, EmailSender>();
//builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

builder.Services.AddAuthentication()
.AddGoogle("Microsoft.AspNetCore.Authentication.AuthenticationScheme", options =>
{
    IConfigurationSection googleAuthNSection =
    config.GetSection("Authentication:Google");
    options.ClientId = "706851683066-ul9ufj5arpsfilq6j0i8ofuj45giof0o.apps.googleusercontent.com";
    options.ClientSecret = "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";
})
.AddFacebook(options =>
{
    IConfigurationSection FBAuthNSection =
    config.GetSection("Authentication:Facebook");
    options.ClientId = "501247168552925";
    options.ClientSecret = "61269738195cfedaf1011573430bec63";
})
.AddMicrosoftAccount(microsoftOptions =>
{
    microsoftOptions.ClientId = "efcc30ed-c75d-4c3b-a1a8-ed7c9c44e498";
    microsoftOptions.ClientSecret = "DH58Q~98v78k~kcz.zJNA641DPBNjC3aW312~aR6";
})
.AddTwitter(twitterOptions =>
{
    twitterOptions.ConsumerKey = "Hp4IImTZmrg57ajyLg7gVYHaN";
    twitterOptions.ConsumerSecret = "QY4UjTddQHfsQ7Eh7zBhhPcMR2jcXvoWK8ZRkyCzmRxKbFAocd";
});

//builder.Services.AddAuthentication()
//.AddGoogle("Microsoft.AspNetCore.Authentication.AuthenticationScheme", options =>
//{
//    IConfigurationSection googleAuthNSection =
//    config.GetSection("Authentication:Google");
//    options.ClientId = googleAuthNSection["ClientId"];
//    options.ClientSecret = googleAuthNSection["ClientSecret"];
//})
//.AddFacebook(options =>
//{
//    IConfigurationSection FBAuthNSection =
//    config.GetSection("Authentication:Facebook");
//    options.ClientId = FBAuthNSection["AppId"];
//    options.ClientSecret = FBAuthNSection["AppSecret"];
//})
//.AddMicrosoftAccount(microsoftOptions =>
//{
//    microsoftOptions.ClientId = config["Authentication:Microsoft:ClientId"];
//    microsoftOptions.ClientSecret = config["Authentication:Microsoft:ClientSecret"];
//})
//.AddTwitter(twitterOptions => 
//{
//    twitterOptions.ConsumerKey = builder.Configuration["Authentication:Twitter:ConsumerAPIKey"];
//    twitterOptions.ConsumerSecret = builder.Configuration["Authentication:Twitter:ConsumerSecret"];
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
