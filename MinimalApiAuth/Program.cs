using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MinimalApiAuth.Helpers;
using MinimalApiAuth.Models;
using MinimalApiAuth.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IUserService, UserService>();

// Add Authentication and Authorization services
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtHelper.SecretKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Add Authorization services
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/register", (User user, IUserService userService) =>
{
    var registeredUser = userService.Register(user);
    return Results.Ok(registeredUser);
});

app.MapPost("/login", (User user, IUserService userService) =>
{
    var authenticatedUser = userService.Authenticate(user.Username, user.Password);
    if (authenticatedUser == null)
    {
        return Results.Unauthorized();
    }
    var token = JwtHelper.GenerateJwtToken(authenticatedUser);
    return Results.Ok(new { Token = token });
});

app.MapGet("/users", (IUserService userService) =>
{
    return Results.Ok(userService.GetAll());
}).RequireAuthorization();

app.Run();
