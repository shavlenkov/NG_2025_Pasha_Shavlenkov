using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.DatabaseContext;

namespace DataAccessLayer.Repositories;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(CrowdfundingDbContext context) : base(context)
    {
    }
}