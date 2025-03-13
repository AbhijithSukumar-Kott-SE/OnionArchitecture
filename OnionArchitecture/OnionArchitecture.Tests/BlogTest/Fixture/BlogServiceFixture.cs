using System;
using AutoMapper;
using Castle.Core.Logging;
using Mongo2Go;
using MongoDB.Driver;
using OnionArchitecture.Application.Mappings;
using OnionArchitecture.Application.Services;
using OnionArchitecture.Infrastructure.DBContext;
using OnionArchitecture.Infrastructure.Repositories;

public class BlogServiceFixture : IDisposable
{
    public MongoDbRunner MongoRunner { get; }
    public IMongoDatabase Database { get; }
    public MongoDbContext DbContext { get; }
    public BlogRepository BlogRepository { get; }
    public BlogService BlogService { get; }
    public IMapper Mapper { get; }

    public BlogServiceFixture()
    {
        // 1️ Start a Mongo2Go instance
        MongoRunner = MongoDbRunner.Start();
        var client = new MongoClient(MongoRunner.ConnectionString);
        Database = client.GetDatabase("TestDb");

        // 2️ Set up MongoDbContext and Repository
        DbContext = new MongoDbContext(client, "TestDb");
        BlogRepository = new BlogRepository(DbContext);

        // 3️ Configure AutoMapper
        var config = new MapperConfiguration(cfg => cfg.AddProfile<BlogProfile>());
        Mapper = config.CreateMapper();

        // 4️ Initialize BlogService
        BlogService = new BlogService(BlogRepository, Mapper);
    }

    public void Dispose()
    {
        MongoRunner.Dispose();
    }
}
