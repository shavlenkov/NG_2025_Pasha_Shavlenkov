namespace BusinessLogicLayer.Models;

public class VoteModel
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
}