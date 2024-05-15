using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MotorbikeRental.Domain.Entities;
using MotorbikeRental.Domain.Interfaces.DataContext;
using MotorbikeRental.Domain.Interfaces.JWT;
using MotorbikeRental.Domain.Interfaces.Repository;
using MotorbikeRental.Domain.Interfaces.Services;
using MotorbikeRental.Domain.Jwt;
using MotorbikeRental.Infrastructure.Automapper;
using MotorbikeRental.Infrastructure.Configuration;
using MotorbikeRental.Infrastructure.Repository;
using MotorbikeRental.Infrastructure.Repository.DataContext;
using MotorbikeRental.Services;
using MotorbikeRental.Services.JWT;
using System.Configuration;
using System.Security.Claims;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IMotorbikeRepository, MotorbikeRepository>();
builder.Services.AddScoped<IMongoContext, MongoContext>();
builder.Services.AddScoped<IMotorbikeService, MotorbikeService>();
builder.Services.AddScoped<IDeliverymanRepository, DeliverymanRepository>();
builder.Services.AddScoped<IDeliverymanService, DeliverymanService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthenticationMBRService, AuthenticationMBRService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();

var mapper = MapperConfig.InitializeAutomapper();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//builder.Services.AddTransient<TokenService>();

builder.Services
    .AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtConfiguration.PrivateKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("admin"));
    options.AddPolicy("Deliveryman", policy => policy.RequireRole("deliveryman"));
});

builder.Services.AddTransient<TokenService>();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

//app.MapGet("/hello", (HttpContext context)
//        => Results.Ok(context.User.Identity?.Name ?? string.Empty))
//    .RequireAuthorization();

app.MapPost("/login", (UserEntity user, TokenService tokenService)
    => tokenService.Generate(user));

app.MapGet("/deliveryman",
        (ClaimsPrincipal user) =>
            Results.Ok(new { message = $"Authenticated as {user.Identity?.Name}" }))
    .RequireAuthorization("Deliveryman");

app.MapGet("/motorbike",
        (ClaimsPrincipal user) =>
            Results.Ok(new { message = $"Authenticated as {user.Identity?.Name}" }))
    .RequireAuthorization("Admin");

app.MapPost("/deliveryman",
        (ClaimsPrincipal user) =>
            Results.Ok(new { message = $"Authenticated as {user.Identity?.Name}" }))
    .RequireAuthorization("Deliveryman");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
