using BusinessObject;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Repository;
using Repositories;
using Repositories.IRepository;
using ImgurAPI.Core;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


var mongoSettings = builder.Configuration.GetSection("MongoSettings").Get<MongoSettings>();

builder.Services.AddSingleton<LBSMongoDBContext>(sp =>
    new LBSMongoDBContext(mongoSettings.ConnectionString, mongoSettings.DatabaseName));

var AIConfiguration = builder.Configuration.GetSection("AIConfiguration").Get<AIConfiguration>();

builder.Services.AddScoped<AIGeneration>(c =>
    new AIGeneration(AIConfiguration.Key));

builder.Services.AddDbContext<LBSDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LBSConnection")));


builder.Services.AddSingleton<EmailSender, EmailSender>();
builder.Services.AddScoped<ImageManager>();
builder.Services.AddScoped<Imgur>(c =>
{
    return new Imgur("7a6d2f59908c75714a5313d928c7b3e7fd30f9be", "d4f0cdf58764de7d91a94bd43aafe095e5c1e820");
});
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
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
