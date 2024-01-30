using Soicheek.BL.ViewModels.Post;
using System.ComponentModel.DataAnnotations;

namespace Soicheek.BL.ViewModels.Blog;

public class BlogVM : ViewModelBase
{
    public int BlogID { get; set; }

    [Required(ErrorMessage = "Název není vyplněn.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Popis není vyplněn.")]
    [MinLength(5, ErrorMessage = "Popis musí mít minimálně 5 znaků.")]
    [MaxLength(500, ErrorMessage = "Popis může mít maximálně 500 znaků.")]
    public string Description { get; set; }
    public List<PostVM>? Posts { get; set; }

    public override int GetHashCode()
    {
        return (BlogID, Name, Description).GetHashCode();
    }
}
