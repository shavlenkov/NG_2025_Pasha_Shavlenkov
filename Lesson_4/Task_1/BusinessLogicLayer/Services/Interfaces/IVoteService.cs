using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces;

public interface IVoteService
{
    Task<IEnumerable<VoteModel>> GetAllVotes();
    Task<VoteModel> GetVoteById(Guid id);
    Task<VoteModel> AddVote(VoteModel voteModel);
    Task<VoteModel> UpdateVote(Guid id, VoteModel voteModel);
    Task<VoteModel> DeleteVote(Guid id);
}