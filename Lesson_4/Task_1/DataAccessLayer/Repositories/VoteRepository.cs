using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.DatabaseContext;

namespace DataAccessLayer.Repositories;

public class VoteRepository : Repository<Vote>, IVoteRepository
{
    public VoteRepository(CrowdfundingDbContext ctx) : base(ctx)
    {
    }
}