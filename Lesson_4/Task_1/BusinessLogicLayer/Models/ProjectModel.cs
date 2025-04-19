namespace BusinessLogicLayer.Models;

public class ProjectModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreationDate { get; set; } = DateTime.Now;

    public Guid CreatorId { get; set; }
    public UserModel Creator { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public CategoryModel Category { get; set; } = null!;
    
    public List<CommentModel> Comments { get; set; }
    public List<VoteModel> Votes { get; set; }
}