using System.ComponentModel.DataAnnotations;
using Soicheek.BL.ViewModels.Blog;

namespace Soicheek.BL.ViewModels.Post;

public class AddPostVM : ViewModelBase
{
    public int BlogID { get; set; }
    [Required(ErrorMessage = "Titulek není vyplněn.")]
    [Display(Name = "Titulek")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "Text není vyplněn.")]
    [Display(Name = "Text")]
    public string? Content { get; set; }
    public DateOnly Date { get; set; }

    public override int GetHashCode()
    {
        return (BlogID, Title, Content, Date).GetHashCode();
    }
}
