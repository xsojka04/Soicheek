using System.ComponentModel.DataAnnotations.Schema;

namespace Soicheek.DAL.DataModels;

public class Blog
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BlogID { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public virtual List<Post>? Posts { get; set; }
}
