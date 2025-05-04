namespace BusinessLogicLayer.Models;

public class ProjectModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    
    public Guid CreatorId { get; set; }
    public Guid CategoryId { get; set; }
}