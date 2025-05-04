using DataAccessLayer.DatabaseContext;

namespace DataAccessLayer.Initializer;

public static class Initializer
{
    public static void InitializeDb(CrowdfundingDbContext ctx)
    {
        ctx.Database.EnsureCreated();
    }
}