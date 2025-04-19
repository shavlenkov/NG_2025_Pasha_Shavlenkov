using DataAccessLayer.DatabaseContext;

namespace DataAccessLayer.Initializer;

public class Initializer
{
    public static void InitializeDb(CrowdfundingDbContext ctx)
    {
        ctx.Database.EnsureCreated();
    }
}