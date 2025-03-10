using FluentAssertions;
using OnionArchitecture.Application.DTOs;
using OnionArchitecture.Application.Services;
using OnionArchitecture.Tests.BlogTest;


public class BlogServiceIntegrationTests : IClassFixture<BlogServiceFixture>
{
    private readonly BlogService _blogService;

    public BlogServiceIntegrationTests(BlogServiceFixture fixture)
    {
        _blogService = fixture.BlogService;
    }

    [Theory]
    [ClassData(typeof(BlogTestData))]
    public async Task AddBlogAsync_ShouldInsertBlogSuccessfully(BlogDto blogDto)
    {
        // Act: Insert blog into MongoDB
        await _blogService.addBlogAsync(blogDto);
        var blogs = await _blogService.getAllBlogsAsync();

        // Assert: Verify that the blog was inserted
        blogs.Should().ContainEquivalentOf(blogDto, options => options.Excluding(b => b.Id));
    }
}
