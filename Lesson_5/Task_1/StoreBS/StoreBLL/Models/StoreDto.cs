namespace StoreBLL.Models;

public class StoreDto
{
    public StoreDto()
    {
        Location = string.Concat(City, Address);
    }
    
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; }
    public string City { get; set; }
    public string Address { get; set; }
}