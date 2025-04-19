namespace DataAccessLayer.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string SecondName { get; set; }
    
    public ICollection<Project> Projects { get; } = new List<Project>();
    public ICollection<Comment> Comments { get; } = new List<Comment>();
    public ICollection<Vote> Votes { get; } = new List<Vote>();
}