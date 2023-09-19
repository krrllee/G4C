using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TwitterCloneBackend.Models;
using TwitterCloneBackend.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using TwitterCloneBackend.Repositories.Interfaces;
using AutoMapper;
using TwitterCloneBackend.Mapping;
using TwitterCloneBackend.Services.Interfaces;
using TwitterCloneBackend.Services;
using Microsoft.OpenApi.Models;
using Microsoft.Exchange.WebServices.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Allow requests from this origin
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();


builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILoginRepository,LoginRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITweetRepository, TweetRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IFollowerRepository, FollowerRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ITweetService, TweetService>();
builder.Services.AddScoped<ITweetRepository, TweetRepository>();
// Add services to the container.
builder.Services.AddDbContext<TwitterDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TwitterCloneDbConnection"));

});

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:44398",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"])),
    };
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebProject", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
