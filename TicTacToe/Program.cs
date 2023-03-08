using Microsoft.EntityFrameworkCore;
using TicTacToe.Models.Context;

var builder = WebApplication.CreateBuilder(args);

// Default Policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins().AllowAnyHeader().AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddControllers();

string dbConnection = builder.Configuration.GetConnectionString("TicTacToeConnection");

builder.Services.AddDbContext<TicTacToeContext>(options => options.UseMySql(dbConnection, ServerVersion.AutoDetect(dbConnection)));

var app = builder.Build();

// Shows UseCors with CorsPolicyBuilder.
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();