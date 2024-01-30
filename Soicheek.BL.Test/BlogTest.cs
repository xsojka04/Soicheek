using Soicheek.BL.Services;
using Soicheek.BL.ViewModels.Blog;
using Soicheek.DAL.DataModels;

namespace Soicheek.BL.Test;

public class BlogTest : IDisposable
{
    private BlogService BlogService { get; set; }
    public TestContext TestContext { get; }

    public BlogTest() 
    { 
        TestContext = new TestContext(GetType().Name);
        var postService = new PostService(TestContext.SoicheekContext, TestContext.Mapper);
        BlogService = new BlogService(TestContext.SoicheekContext, TestContext.Mapper, postService);
    }

    [Fact]
    public async Task AddTest()
    {
        var addBlogVM = new AddBlogVM() { Name = "testname", Description = "testtext" };
        var blogVM = await BlogService.AddAsync(addBlogVM);
        Assert.NotNull(blogVM);
        var foundBlogVM = await BlogService.GetByIdAsync(blogVM.BlogID);
        Assert.Equal(blogVM, foundBlogVM);
    }

    [Fact]
    public async Task UpdateTest()
    {
        var addBlogVM = new AddBlogVM() { Name = "testname", Description = "testtext" };
        var blogVM = await BlogService.AddAsync(addBlogVM);
        Assert.NotNull(blogVM);
        blogVM.Name = "ahoj";
        await BlogService.UpdateAsync(blogVM);
        var updatedBlogVM = await BlogService.GetByIdAsync(blogVM.BlogID);
        Assert.Equal(blogVM, updatedBlogVM);
    }

    public void Dispose()
    {
        TestContext?.Dispose();
    }
}