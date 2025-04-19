namespace DataAccessLayer.Entities;

public class Comment : BaseEntity
{
    public string Text { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    
    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;
}