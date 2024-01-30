using Soicheek.BL.ViewModels.Post;
using Soicheek.DAL.DataModels;
using System.ComponentModel.DataAnnotations;

namespace Soicheek.BL.ViewModels.Blog;

public class AddBlogVM : ViewModelBase
{
    [Required(ErrorMessage = "Název není vyplněn.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Popis není vyplněn.")]
    [MinLength(5, ErrorMessage = "Popis musí mít minimálně 5 znaků.")]
    [MaxLength(500, ErrorMessage = "Popis může mít maximálně 500 znaků.")]
    public string? Description { get; set; }

    public override int GetHashCode()
    {
        return (Name, Description).GetHashCode();
    }
}
