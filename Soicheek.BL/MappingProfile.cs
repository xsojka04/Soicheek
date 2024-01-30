using Soicheek.DAL.DataModels;
using AutoMapper;
using Soicheek.BL.ViewModels.Blog;
using Soicheek.BL.ViewModels.Post;

namespace Soicheek.BL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Blog, BlogVM>().ReverseMap();
            CreateMap<Blog, AddBlogVM>().ReverseMap();

            CreateMap<Post, PostVM>().ReverseMap();
            CreateMap<Post, AddPostVM>().ReverseMap();
        }
    }
}
