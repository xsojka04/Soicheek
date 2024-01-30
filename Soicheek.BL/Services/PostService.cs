using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Soicheek.BL.Services.Interfaces;
using Soicheek.BL.ViewModels.Blog;
using Soicheek.BL.ViewModels.Post;
using Soicheek.DAL;
using Soicheek.DAL.DataModels;

namespace Soicheek.BL.Services
{
    public class PostService : IPostService
    {
        public SoicheekContext SoicheekContext { get; }
        public IMapper Mapper { get; }

        public PostService(SoicheekContext soicheekContext, IMapper mapper)
        {
            SoicheekContext = soicheekContext;
            Mapper = mapper;
        }

        public async Task<PostVM?> AddAsync(AddPostVM addPostVM)
        {
            var post = Mapper.Map<Post>(addPostVM);
            await SoicheekContext.Posts.AddAsync(post);
            await SoicheekContext.SaveChangesAsync();
            return Mapper.Map<PostVM?>(post);
        }

        public async Task<List<PostVM>> GetAllAsync()
        {
            var posts= await SoicheekContext.Posts.AsNoTracking().ToListAsync();
            return Mapper.Map<List<PostVM>>(posts);
        }

        public async Task<List<PostVM>> GetByBlogIdAsync(int blogID)
        {
            var posts = await SoicheekContext.Posts.AsNoTracking().Where(x => x.BlogID == blogID).OrderBy(x => x.Date).ToListAsync();
            return Mapper.Map<List<PostVM>>(posts);
        }

        public async Task<PostVM?> GetByIdAsync(int postId)
        {
            var post = await SoicheekContext.Posts.AsNoTracking().FirstOrDefaultAsync(x => x.PostID == postId);
            return Mapper.Map<PostVM?>(post);
        }

        public async Task RemoveAsync(int postId)
        {
            var post = await SoicheekContext.Posts.FirstOrDefaultAsync(x => x.PostID == postId);
            if (post is not null)
            {
                SoicheekContext.Posts.Remove(post);
            }
            await SoicheekContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PostVM postVM)
        {
            var post = await SoicheekContext.Posts.FirstAsync(x => x.PostID == postVM.PostID);
            Mapper.Map(postVM, post);
            SoicheekContext.Entry(post).State = EntityState.Modified;
            await SoicheekContext.SaveChangesAsync();
        }
    }
}
