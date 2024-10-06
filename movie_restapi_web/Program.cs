//using AspNetCoreWebAPI8.Models;
using Microsoft.EntityFrameworkCore;
using movie_restapi_web.Models;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);
/*
DotNetEnv.Env.Load();


var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DBCon");
if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection string not found. Ensure the .env file is correctly configured and placed in the root directory.");
}

// Add connection string to the applications configuration system
builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
{
    {"ConnectionStrings:MovieContext", connectionString }
}.Select(x => new KeyValuePair<string, string?>(x.Key, x.Value)));

*/

// Add services to the container.
var Configuration = builder.Configuration;
builder.Services.AddDbContext<MovieContext> (options =>
options.UseNpgsql(Configuration.GetConnectionString("MovieContext")));
//    options.UseNpgsql(connectionString));  // Use the connection string directly

//builder.Services.AddDbContext<MovieContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContext")));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
