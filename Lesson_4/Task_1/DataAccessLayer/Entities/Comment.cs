﻿namespace DataAccessLayer.Entities;

public class Comment : BaseEntity
{
    public string Text { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    
    public virtual User User { get; set; }
    public virtual Project Project { get; set; }
}