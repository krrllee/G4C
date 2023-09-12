using Microsoft.EntityFrameworkCore;
using TwitterCloneBackend.Models;
using TwitterCloneBackend.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITweetRepository, TweetRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

// Add services to the container.
builder.Services.AddDbContext<TwitterDbContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-7ETRDLF\\SQLEXPRESS;Database=TwitterCloneDb;Trusted_Connection=true;TrustServerCertificate=True");

});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
