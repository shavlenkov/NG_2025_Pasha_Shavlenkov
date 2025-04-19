namespace DataAccessLayer.Entities;

public class Category : BaseEntity
{
    public string Description { get; set; }
    
    public ICollection<Project> Projects { get; } = new List<Project>();
}