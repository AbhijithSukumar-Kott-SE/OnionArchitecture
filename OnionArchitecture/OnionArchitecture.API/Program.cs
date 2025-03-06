using OnionArchitecture.Application.Interfaces;
using OnionArchitecture.Core.Interfaces;
using OnionArchitecture.Infrastructure.DBContext;
using OnionArchitecture.Infrastructure.Repositories;

using OnionArchitecture.Application.Mappings;
using OnionArchitecture.Application.Services;


var builder = WebApplication.CreateBuilder(args);


var configuration = builder.Configuration;


builder.Services.AddControllers();

builder.Services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<MongoDbContext>();

builder.Services.AddScoped<IBlogRepository, BlogRepository>();

builder.Services.AddScoped<IBlogService, BlogService>();

builder.Services.AddAutoMapper(typeof(BlogProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
