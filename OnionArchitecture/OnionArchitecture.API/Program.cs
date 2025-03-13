using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnionArchitecture.Infrastructure.DBContext;
using OnionArchitecture.Application.Interfaces;
using OnionArchitecture.Infrastructure.Repositories;
using OnionArchitecture.Application.Services;
using OnionArchitecture.Infrastructure;
using OnionArchitecture.Application.Mappings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//  Load Configuration from appsettings.json
var configuration = builder.Configuration;

//  Retrieve MongoDB Connection String and Database Name
var connectionString = builder.Configuration["MongoDbSettings:ConnectionString"]
                      ?? throw new ArgumentNullException("MongoDB connection string is missing!");

var databaseName = builder.Configuration["MongoDbSettings:DatabaseName"]
                   ?? throw new ArgumentNullException("MongoDB database name is missing!");

//  Register MongoDB Client
builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient(connectionString));

//  Register Infrastructure Layer Dependencies
builder.Services.AddInfrastructureServices(configuration);

//  Register Application Layer Dependencies
builder.Services.AddScoped<IBlogService, BlogService>();

// Register MediatR with Application layer assembly
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(OnionArchitecture.Application.Commands.BlogCommands.AddBlogCommand).Assembly));


//  Add Controllers
builder.Services.AddControllers();

//  Add AutoMapper
builder.Services.AddAutoMapper(typeof(BlogProfile));

//  Add Swagger for API Documentation (Optional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//  Enable Swagger in Development Mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable Routing & Controllers
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
