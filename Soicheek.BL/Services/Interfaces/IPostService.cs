using Soicheek.BL.ViewModels.Post;

namespace Soicheek.BL.Services.Interfaces
{
    public interface IPostService
    {
        public Task<List<PostVM>> GetAllAsync();
        public Task<PostVM?> GetByIdAsync(int postId);
        public Task UpdateAsync(PostVM postVM);
        public Task<PostVM?> AddAsync(AddPostVM addPostVM);
        public Task RemoveAsync(int postId);
    }
}
