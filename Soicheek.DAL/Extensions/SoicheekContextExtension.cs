using Microsoft.EntityFrameworkCore;
using Soicheek.DAL.DataModels;
using Soicheek.DAL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Soicheek.DAL.Extensions
{
    public static class SoicheekContextExtension
    {
        public static void Seed(this SoicheekContext context)
        {
            context.Database.EnsureCreated();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var programovaniBlogId = 1;
            var uceniBlogId = 2;
            var blogs = new List<Blog>()
            {
                new Blog { BlogID = programovaniBlogId, Name = "Programování", Description = "Programování je useful skill.", Posts = new List<Post>() },
                new Blog { BlogID = uceniBlogId, Name = "Učení", Description = "Člověk se učí celý život.", Posts = new List<Post>() }
            };
            context.Blogs.AddRange(blogs);
            context.SaveChanges();

            var posts = new List<Post>()
            {
                new Post { PostID = 1, BlogID = programovaniBlogId, Title = "C#", Content = "Učit se novým věcem v C# je odměňující.", Date = new DateOnly(2022, 12, 21) },
                new Post { PostID = 2, BlogID = programovaniBlogId, Title = "PHP", Content = "Existují případy, kdy je toto vhodný kandidát na tvorbu něčeho.", Date = new DateOnly(2021, 1, 2) },
                new Post { PostID = 3, BlogID = uceniBlogId, Title = "Doporučovací algoritmy", Content = "Široká veřejnost se potřebuje naučit, jak fungují doporučovací algoritmy na sociálních sítích.", Date = new DateOnly(2023, 8, 10) }
            };
            context.Posts.AddRange(posts);
            context.SaveChanges();
        }
    }
}
