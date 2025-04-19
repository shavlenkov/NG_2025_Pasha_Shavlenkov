using AutoMapper;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services;

public class VoteService : IVoteService
{
    private readonly IVoteRepository _voteRepository;
    private readonly IMapper _mapper;

    public VoteService(IVoteRepository voteRepository, IMapper mapper)
    {
        _voteRepository = voteRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<VoteModel>> GetAllAsync()
    {
        var votes = await _voteRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<VoteModel>>(votes);
    }
    
    public async Task<VoteModel?> GetByIdAsync(Guid id)
    {
        var vote = await _voteRepository.GetByIdAsync(id);
        
        if (vote == null)
        {
            return null;
        }
        
        return _mapper.Map<VoteModel>(vote);
    }
    
    public async Task<VoteModel> CreateAsync(VoteModel voteModel)
    {
        var createdVote = await _voteRepository.AddAsync(_mapper.Map<Vote>(voteModel));
        
        return _mapper.Map<VoteModel>(createdVote);
    }
    
    public async Task<VoteModel?> UpdateAsync(Guid id, VoteModel voteModel)
    {
        var vote = await _voteRepository.GetByIdAsync(id);

        if (vote == null)
        {
            return null;
        }

        vote.UserId = voteModel.UserId;
        vote.ProjectId = voteModel.ProjectId;

        var updatedVote = await _voteRepository.UpdateAsync(vote);
        
        return _mapper.Map<VoteModel>(updatedVote);
    }

    public async Task<VoteModel?> DeleteAsync(Guid id)
    { 
        var vote = await _voteRepository.GetByIdAsync(id);
        
        if (vote == null)
        {
            return null;
        }
        
        var deletedVote = await _voteRepository.DeleteAsync(vote);
        
        return _mapper.Map<VoteModel>(deletedVote);
    }
}