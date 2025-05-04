using AutoMapper;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services;

public class VoteService : IVoteService
{
    private readonly IVoteRepository _voteRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    
    public VoteService(
        IVoteRepository voteRepository, 
        IUserRepository userRepository, 
        IProjectRepository projectRepository, 
        IMapper mapper)
    {
        _voteRepository = voteRepository;
        _userRepository = userRepository;
        _projectRepository = projectRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<VoteModel>> GetAllVotes()
    {
        var votes = await _voteRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<VoteModel>>(votes);
    }
    
    public async Task<VoteModel> GetVoteById(Guid id)
    {
        var vote = await _voteRepository.GetByIdAsync(id);
        
        if (vote == null)
        {
            throw new KeyNotFoundException($"Vote with id '{id}' was not found");
        }
        
        return _mapper.Map<VoteModel>(vote);
    }
    
    public async Task<VoteModel> AddVote(VoteModel voteModel)
    {
        if (await _userRepository.GetByIdAsync(voteModel.UserId) == null)
        {
            throw new InvalidOperationException($"User with id '{voteModel.UserId}' does not exist");
        }
        
        if (await _projectRepository.GetByIdAsync(voteModel.ProjectId) == null)
        {
            throw new InvalidOperationException($"Project with id '{voteModel.ProjectId}' does not exist");
        }
        
        var vote = _mapper.Map<Vote>(voteModel);
        
        var addedVote = await _voteRepository.AddAsync(vote);
        
        return _mapper.Map<VoteModel>(addedVote);
    }
    
    public async Task<VoteModel> UpdateVote(Guid id, VoteModel voteModel)
    {
        var vote = await _voteRepository.GetByIdAsync(id);
        
        if (vote == null)
        {
            throw new KeyNotFoundException($"Vote with id '{id}' was not found");
        }
        
        if (await _userRepository.GetByIdAsync(voteModel.UserId) == null)
        {
            throw new InvalidOperationException($"User with id '{voteModel.UserId}' does not exist");
        }
        
        if (await _projectRepository.GetByIdAsync(voteModel.ProjectId) == null)
        {
            throw new InvalidOperationException($"Project with id '{voteModel.ProjectId}' does not exist");
        }
        
        vote.UserId = voteModel.UserId;
        vote.ProjectId = voteModel.ProjectId;
        
        var updatedVote = await _voteRepository.UpdateAsync(vote);
        
        return _mapper.Map<VoteModel>(updatedVote);
    }
    
    public async Task<VoteModel> DeleteVote(Guid id)
    { 
        var vote = await _voteRepository.GetByIdAsync(id);
        
        if (vote == null)
        {
            throw new KeyNotFoundException($"Vote with id '{id}' was not found");
        }
        
        var deletedVote = await _voteRepository.DeleteAsync(vote);
        
        return _mapper.Map<VoteModel>(deletedVote);
    }
}