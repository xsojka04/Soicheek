using Microsoft.EntityFrameworkCore;
using Soicheek.DAL.DataModels;
using Soicheek.DAL.Extensions;

namespace Soicheek.DAL.Test
{
    public class BlogTest : IDisposable
    {
        private readonly TestContext testContext;

        public BlogTest()
        {
            testContext = new TestContext(GetType().Name);
        }

        [Fact]
        public async Task AddTest()
        {
            var blog = new Blog { Name = "xx", Description = "x" };
            await testContext.SoicheekContext.Blogs.AddAsync(blog);
            await testContext.SoicheekContext.SaveChangesAsync();
            blog = await testContext.SoicheekContext.Blogs.FirstOrDefaultAsync(x => x.Name == "xx");
            Assert.NotNull(blog);
            Assert.Equal("x", blog.Description);
        }
        
        [Fact]
        public async Task UpdateTest()
        {
            var blog = new Blog { Name = "xx", Description = "x" };
            await testContext.SoicheekContext.Blogs.AddAsync(blog);
            await testContext.SoicheekContext.SaveChangesAsync();
            var blog2 = await testContext.SoicheekContext.Blogs.FirstOrDefaultAsync(x => x.Name == "xx");
            Assert.NotNull(blog);
            if (blog2 is null) { throw new Exception(); }
            blog2.Description = "y";
            testContext.SoicheekContext.Blogs.Update(blog2);
            await testContext.SoicheekContext.SaveChangesAsync();
            Assert.Equal("y", blog2.Description);
        }

        public void Dispose()
        {
            testContext.Dispose();
        }
    }
}