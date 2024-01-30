using Soicheek.BL.ViewModels.Blog;

namespace Soicheek.BL.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<BlogVM>> GetAllAsync();
        Task<BlogVM?> GetByIdAsync(int blogId);
        Task UpdateAsync(BlogVM blogVM);
        Task<BlogVM?> AddAsync(AddBlogVM addBlogVM);
        Task RemoveAsync(int blogId);
    }
}
