namespace DataAccessLayer.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    
    public Guid CreatorId { get; set; }
    public User Creator { get; set; } = null!;
    
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    
    public ICollection<Comment> Comments { get; } =  new List<Comment>();
    public ICollection<Vote> Votes { get; } =  new List<Vote>();
}