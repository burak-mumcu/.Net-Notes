using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OpenTelemetry.Trace;
using OpenTelemetry.Resources;
using OpenTelemetry.Exporter;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Serilog Configuration for Centralized Logging

// JWT Authentication Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "yourdomain.com",
            ValidAudience = "yourdomain.com",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"))
        };
    });
/*
 * paketlerin kullanýmdan kaldýrýlmasýyla ilgili hatalar mevcut ; muadil paketler incelenebilir
// Polly Configuration for Circuit Breaker, Bulkhead, Retry, and Timeout
builder.Services.AddHttpClient("MyClient")
    .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking: 2, durationOfBreak: TimeSpan.FromSeconds(30)))
    .AddTransientHttpErrorPolicy(p => p.BulkheadAsync(maxParallelization: 10, maxQueuingActions: 100))
    .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)))
    .AddTransientHttpErrorPolicy(p => p.TimeoutAsync(TimeSpan.FromSeconds(10)));

// OpenTelemetry Configuration for Distributed Tracing (Jaeger)
builder.Services.AddOpenTelemetryTracing(tracerProviderBuilder =>
{
    tracerProviderBuilder
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("YourServiceName"))
        .AddAspNetCoreInstrumentation()
        .AddJaegerExporter(o =>
        {
            o.AgentHost = "localhost";
            o.AgentPort = 6831;
        });
}); */

// Health Check Configuration
builder.Services.AddHealthChecks();

builder.Services.AddControllers();

var app = builder.Build();

// Middleware for Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health");
});

app.Run();
