namespace BusinessLogicLayer.Models;

public class CommentModel
{
    public Guid Id { get; set; }
    
    public string Text { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
}