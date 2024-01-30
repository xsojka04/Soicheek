using System.ComponentModel.DataAnnotations.Schema;

namespace Soicheek.DAL.DataModels;

public class Post
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PostID { get; set; }
    public int BlogID { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateOnly Date { get; set; }

    public virtual Blog Blog { get; set; }
}
