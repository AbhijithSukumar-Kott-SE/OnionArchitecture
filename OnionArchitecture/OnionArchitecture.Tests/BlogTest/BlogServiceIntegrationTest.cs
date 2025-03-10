using AutoMapper;
using FluentAssertions;
using Mongo2Go;
using MongoDB.Driver;
using OnionArchitecture.Application.Mappings;
using OnionArchitecture.Application.Services;
using OnionArchitecture.Core.Models;
using OnionArchitecture.Infrastructure.DBContext;
using OnionArchitecture.Infrastructure.Repositories;


namespace OnionArchitecture.Tests.BlogTest
{
    public class BlogServiceIntegrationTest : IAsyncLifetime
    {
        private readonly MongoDbRunner _mongoDbRunner;
        private readonly BlogRepository _blogRepository;
        private readonly BlogService _blogService;
        private readonly MongoDbContext _mongoDBContext;

        public BlogServiceIntegrationTest()
        {
            try
            {
                //Start in-memory MongoDB instance
                _mongoDbRunner = MongoDbRunner.Start();

                //Create Mongo Client
                var client = new MongoClient(_mongoDbRunner.ConnectionString);


                _mongoDBContext = new MongoDbContext(client, "TestDB");

                _blogRepository = new BlogRepository(_mongoDBContext);

                //Setup AutoMapper
                var mapperConfig = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<BlogProfile>(); // Use existing AutoMapper profile
                });

                var mapper = mapperConfig.CreateMapper();

                //Initialize BlogService
                _blogService = new BlogService(_blogRepository, mapper);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Exception : - {e.Message}");
            }

        }
        public Task DisposeAsync()
        {
            _mongoDbRunner.Dispose();
            return Task.CompletedTask;
        }

        public async Task InitializeAsync()
        {
            var blogs = new List<Blog>
            {
                new Blog{Title="Title 1",Content="Test Content 1",Publisher="Publisher 1"},
                new Blog{Title="Title 2",Content="Test Content 2",Publisher="Publisher 2"},
                new Blog{Title="Title 3",Content="Test Content 3",Publisher="Publisher 3"}
            };

            await _mongoDBContext.Blogs.InsertManyAsync(blogs);
        }

        [Fact]
        public async Task GetAllBlogsAsync_ShouldReturnListOfDtos()
        {
            //Act
            var result = await _blogService.getAllBlogsAsync();


            //Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);
        }
    }
}
