using AutoMapper;
using FluentAssertions;
using NSubstitute;
using OnionArchitecture.Application.DTOs;
using OnionArchitecture.Application.Interfaces;
using OnionArchitecture.Application.Services;
using OnionArchitecture.Core.Interfaces;
using OnionArchitecture.Core.Models;


namespace OnionArchitecture.Tests.BlogTest
{
    public class BlogServiceTest
    {
        private readonly IBlogRepository _mockBlogRepository;
        private readonly IBlogService _blogService;
        private readonly IMapper _mockMapper;


        public BlogServiceTest()
        {
            _mockBlogRepository = Substitute.For<IBlogRepository>();
            _mockMapper = Substitute.For<IMapper>();
            _blogService = new BlogService(_mockBlogRepository,_mockMapper);
        }


        [Fact]
        public async Task GetAllBlogsAsync_ShouldReturnListOfBlogDtos()
        {

            //Arrange
            var blogs = new List<Blog>
            {
                new Blog{Id="1",Title="Title 1",Content="Test Content 1",Publisher="Publisher 1"},
                new Blog{Id="2",Title="Title 2",Content="Test Content 2",Publisher="Publisher 2"},
                new Blog{Id="3",Title="Title 3",Content="Test Content 3",Publisher="Publisher 3"}

            };

            var expectedBlogDtos = new List<BlogDto>
            {
                new BlogDto{Id="1",Title="Title 1",Content="Test Content 1",Publisher="Publisher 1"},
                new BlogDto{Id="2",Title="Title 2",Content="Test Content 2",Publisher="Publisher 2"},
                new BlogDto{Id="3",Title="Title 3",Content="Test Content 3",Publisher="Publisher 3"}
            };

            _mockBlogRepository.getAllBlogsAsync().Returns(blogs);
            _mockMapper.Map<IEnumerable<BlogDto>>(blogs).Returns(expectedBlogDtos);

            //Act
            var result =await _blogService.getAllBlogsAsync();


            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedBlogDtos);
            result.Should().HaveCount(3);
  


        }


        [Fact]
        public async Task GetAllBlogsAsync_ShouldReturnEmptyList_WhenNoBlogExist()
        {
            //Arrange
            var emptyBlogs = new List<Blog>();
            _mockBlogRepository.getAllBlogsAsync().Returns(emptyBlogs);
            _mockMapper.Map<IEnumerable<BlogDto>>(emptyBlogs).Returns(new List<BlogDto>());

            //Act
            var result = await _blogService.getAllBlogsAsync();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }
    }
}
