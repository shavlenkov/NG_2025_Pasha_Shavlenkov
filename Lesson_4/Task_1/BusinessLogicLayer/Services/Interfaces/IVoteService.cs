using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces;

public interface IVoteService
{
    Task<IEnumerable<VoteModel>> GetAllAsync();
    Task<VoteModel?> GetByIdAsync(Guid id);
    Task<VoteModel> CreateAsync(VoteModel voteModel);
    Task<VoteModel?> UpdateAsync(Guid id, VoteModel voteModel);
    Task<VoteModel?> DeleteAsync(Guid id);
}