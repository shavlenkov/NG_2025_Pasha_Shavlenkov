namespace BusinessLogicLayer.Models;

public class VoteModel
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    public UserModel User { get; set; } = null!;
    
    public Guid ProjectId { get; set; }
    public ProjectModel Project { get; set; } = null!;
}