using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Soicheek.BL.Services.Interfaces;
using Soicheek.BL.ViewModels.Blog;
using Soicheek.DAL;
using Soicheek.DAL.DataModels;

namespace Soicheek.BL.Services
{
    public class BlogService : IBlogService
    {
        public SoicheekContext SoicheekContext { get; }
        public PostService PostService { get; }
        public IMapper Mapper { get; }

        public BlogService(SoicheekContext soicheekContext, IMapper mapper, PostService postService) 
        {
            SoicheekContext = soicheekContext;
            PostService = postService;
            Mapper = mapper;
        }

        public async Task<BlogVM?> AddAsync(AddBlogVM addBlogVM)
        {
            var blog = Mapper.Map<Blog>(addBlogVM);
            await SoicheekContext.Blogs.AddAsync(blog);
            await SoicheekContext.SaveChangesAsync();
            return Mapper.Map<BlogVM?>(blog);
        }

        public async Task<List<BlogVM>> GetAllAsync()
        {
            var blogs = await SoicheekContext.Blogs.AsNoTracking().OrderBy(x => x.BlogID).ToListAsync();
            return Mapper.Map<List<BlogVM>>(blogs);
        }

        public async Task<BlogVM?> GetByIdAsync(int blogId)
        {
            var blog = await SoicheekContext.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.BlogID == blogId);
            var blogVM = Mapper.Map<BlogVM?>(blog);
            if (blogVM is not null)
            {
                blogVM.Posts = await PostService.GetByBlogIdAsync(blogId);
            }
            return blogVM;
        }

        public async Task RemoveAsync(int blogId)
        {
            var posts = await SoicheekContext.Posts.Where(x => x.BlogID == blogId).ToListAsync();
            foreach (var post in posts)
            {
                SoicheekContext.Posts.Remove(post);

            }
            var blog = await SoicheekContext.Blogs.FirstOrDefaultAsync(x => x.BlogID == blogId);
            if (blog is not null)
            {
                SoicheekContext.Blogs.Remove(blog);
            }
            await SoicheekContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(BlogVM blogVM)
        {
            var blog = await SoicheekContext.Blogs.FirstAsync(x => x.BlogID == blogVM.BlogID);
            Mapper.Map(blogVM, blog);
            SoicheekContext.Entry(blog).State = EntityState.Modified;
            await SoicheekContext.SaveChangesAsync();
        }
    }
}
