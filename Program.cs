using SingletonTransientScopeDemo.Interfaces;
using SingletonTransientScopeDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddKeyedSingleton<IService, SingletonService>(ServiceType.Singleton);
builder.Services.AddKeyedScoped<IService, ScopedService>(ServiceType.Scoped);
builder.Services.AddKeyedTransient<IService, TransientService>(ServiceType.Transient);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
