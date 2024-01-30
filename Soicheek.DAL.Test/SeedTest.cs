using Microsoft.EntityFrameworkCore;
using Soicheek.DAL.Extensions;

namespace Soicheek.DAL.Test
{
    public class SeedTest : IDisposable
    {
        private readonly TestContext testContext;

        public SeedTest()
        {
            testContext = new TestContext(GetType().Name);
            testContext.SoicheekContext.Seed();
        }

        [Fact]
        public async Task BlogCountTest()
        {
            var blogs = await testContext.SoicheekContext.Blogs.ToListAsync();
            Assert.Equal(2, blogs.Count());
        }

        [Fact]
        public async Task PostCountTest()
        {
            var posts = await testContext.SoicheekContext.Posts.ToListAsync();
            Assert.Equal(3, posts.Count());
        }

        public void Dispose()
        {
            testContext.Dispose();
        }
    }
}