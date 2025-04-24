using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using IReadingWeb.Hubs;
using IReadingWeb.Service.Payment;
using IReadingWeb.Service.UserConnection;
using LBSWeb.API;
using LBSWeb.Service.Book;
using LBSWeb.Service.Information;
using LBSWeb.Services.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle("Google", options =>
{
    options.ClientId = builder.Configuration["GoogleKey:ClientId"].ToString();
    options.ClientSecret = builder.Configuration["GoogleKey:ClientSecret"].ToString();
    options.CallbackPath = "/signin-google";

    //options.Events = new OAuthEvents
    //{
    //    OnTicketReceived = context =>
    //    {
    //        context.ReturnUri = "Account/LoginWithGoogle";
    //        return Task.CompletedTask;
    //    }
    //};
});

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("/app/keys"))
    .SetApplicationName("IReading");

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.Secure = CookieSecurePolicy.Always;
});

builder.Services.AddHttpContextAccessor();

// Declare DI

builder.Services.AddSingleton<WebAPICaller, WebAPICaller>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IInformationService, InformationService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddSingleton<IUserConnectionManager, UserConnectionManager>();
//SignalR DI
builder.Services.AddSignalR();

// Config Auto ValidateAntiforgery Token
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.AddHttpClient();

builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
}
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});


//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Account/EmailConfirmSender");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedProto | ForwardedHeaders.XForwardedFor
});

app.UseStaticFiles();

app.UseRouting();

app.UseNotyf();

app.UseCookiePolicy();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Account}/{action=Login}/{id?}");
    pattern: "{controller=Account}/{action=Login}/{id?}");
    //pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chathub");

app.Run();
