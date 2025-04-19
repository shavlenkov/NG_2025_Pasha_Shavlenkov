namespace BusinessLogicLayer.Models;

public class CommentModel
{
    public Guid Id { get; set; }
    
    public string Text { get; set; } = null!;
    public DateTime Date { get; set; } = DateTime.Now;

    public Guid UserId { get; set; }
    public UserModel User { get; set; } = null!;
    public Guid ProjectId { get; set; }
    
    public ProjectModel Project { get; set; } = null!;
}