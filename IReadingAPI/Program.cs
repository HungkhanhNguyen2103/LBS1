using BusinessObject;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Repository;
using Repositories;
using Repositories.IRepository;
using ImgurAPI.Core;
using Microsoft.Extensions.DependencyInjection;
using Net.payOS;
using IReadingAPI;

var builder = WebApplication.CreateBuilder(args);


var mongoSettings = builder.Configuration.GetSection("MongoSettings").Get<MongoSettings>();

builder.Services.AddSingleton<LBSMongoDBContext>(sp =>
    new LBSMongoDBContext(mongoSettings.ConnectionString, mongoSettings.DatabaseName));

var AIConfiguration = builder.Configuration.GetSection("AIConfiguration").Get<AIConfiguration>();

builder.Services.AddScoped<AIGeneration>(c =>
    new AIGeneration(AIConfiguration.Key));

builder.Services.AddDbContext<LBSDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LBSConnection")));

builder.Services.AddScoped<IBookIndexingRepository, BookIndexingRepository>();
builder.Services.AddHostedService<BackgroundTask>();

builder.Services.AddSingleton<EmailSender, EmailSender>();
builder.Services.AddScoped<ImageManager>();
builder.Services.AddScoped<GoogleCredentialService>();
builder.Services.AddScoped<PayOS>(c =>
{
    return new PayOS("fcbfa365-f706-4bf7-b3df-8be2d236b8a1", "cf7d6e36-22b5-4f85-a16a-15cab19a1550", "91934f6634e4e0909341a6f9e100fa9ffe336cbea42a79ab296de7450082ea80");
});
builder.Services.AddScoped<Imgur>(c =>
{
    return new Imgur("7a6d2f59908c75714a5313d928c7b3e7fd30f9be", "d4f0cdf58764de7d91a94bd43aafe095e5c1e820");
});
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IInformationRepository, InformationRepository>();

// For Identity
builder.Services.AddIdentity<Account, IdentityRole>()
    .AddEntityFrameworkStores<LBSDbContext>()
    .AddDefaultTokenProviders();


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
