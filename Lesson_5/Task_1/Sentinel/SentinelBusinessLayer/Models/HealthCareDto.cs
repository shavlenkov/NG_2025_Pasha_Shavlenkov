namespace SentinelBusinessLayer.Models;

public class HealthCareDto
{
    public string TreatmentName { get; set; }
    public DateTime InjectedAt { get; set; }
    public DateTime ExpirationDate { get; set; }
        
    public Guid PetId { get; set; }
    public Guid VendorId { get; set; }
}