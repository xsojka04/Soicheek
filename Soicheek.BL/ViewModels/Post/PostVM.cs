using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Soicheek.BL.ViewModels.Blog;

namespace Soicheek.BL.ViewModels.Post;

public class PostVM : ViewModelBase
{
    public int PostID { get; set; }
    public int BlogID { get; set; }
    [Required(ErrorMessage = "Titulek není vyplněn.")]
    [Display(Name = "Titulek")]
    public required string Title { get; set; }
    [Required(ErrorMessage = "Text není vyplněn.")]
    [Display(Name = "Text")]
    public required string Content { get; set; }
    public DateOnly Date { get; set; }
    public virtual BlogVM? Blog { get; set; }

    public override int GetHashCode()
    {
        return (PostID, BlogID, Title, Content, Date).GetHashCode();
    }
}
