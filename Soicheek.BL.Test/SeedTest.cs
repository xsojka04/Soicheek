using Soicheek.BL.Services;
using Soicheek.DAL.Extensions;

namespace Soicheek.BL.Test;

public class SeedTest : IDisposable
{
    private BlogService BlogService { get; set; }
    private PostService PostService { get; set; }
    public TestContext TestContext { get; }

    public SeedTest() 
    { 
        TestContext = new TestContext(GetType().Name);
        TestContext.SoicheekContext.Seed();
        PostService = new PostService(TestContext.SoicheekContext, TestContext.Mapper);
        BlogService = new BlogService(TestContext.SoicheekContext, TestContext.Mapper, PostService);
    }

    [Fact]
    public async Task BlogCountTest()
    {
        var blogs = await BlogService.GetAllAsync();
        Assert.Equal(2, blogs.Count());
    }

    [Fact]
    public async Task PostCountTest()
    {
        var posts = await PostService.GetAllAsync();
        Assert.Equal(3, posts.Count());
    }

    public void Dispose()
    {
        TestContext?.Dispose();
    }
}