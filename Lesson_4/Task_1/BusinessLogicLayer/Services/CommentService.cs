using AutoMapper;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    
    public CommentService(
        ICommentRepository commentRepository, 
        IUserRepository userRepository, 
        IProjectRepository projectRepository, 
        IMapper mapper)
    {
        _commentRepository = commentRepository;
        _userRepository =  userRepository;
        _projectRepository = projectRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<CommentModel>> GetAllAsync()
    {
        var comments = await _commentRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<CommentModel>>(comments);
    }
    
    public async Task<CommentModel> GetByIdAsync(Guid id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        
        if (comment == null)
        {
            throw new KeyNotFoundException($"Comment with id '{id}' was not found");
        }
        
        return _mapper.Map<CommentModel>(comment);
    }
    
    public async Task<CommentModel> CreateAsync(CommentModel commentModel)
    {
        var comment = _mapper.Map<Comment>(commentModel);
        
        if (await _userRepository.GetByIdAsync(comment.UserId) == null)
        {
            throw new InvalidOperationException($"User with id '{comment.UserId}' does not exist");
        }
        
        if (await _projectRepository.GetByIdAsync(comment.ProjectId) == null)
        {
            throw new InvalidOperationException($"Project with id '{comment.ProjectId}' does not exist");
        }
        
        var createdComment = await _commentRepository.AddAsync(comment);
        
        return _mapper.Map<CommentModel>(createdComment);
    }
    
    public async Task<CommentModel> UpdateAsync(Guid id, CommentModel commentModel)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        
        if (comment == null)
        {
            throw new KeyNotFoundException($"Comment with id '{id}' was not found");
        }
        
        if (await _userRepository.GetByIdAsync(comment.UserId) == null)
        {
            throw new InvalidOperationException($"User with id '{comment.UserId}' does not exist");
        }
        
        if (await _projectRepository.GetByIdAsync(comment.ProjectId) == null)
        {
            throw new InvalidOperationException($"Project with id '{comment.ProjectId}' does not exist");
        }
        
        comment.Text =  commentModel.Text;
        comment.UserId = commentModel.UserId;
        comment.ProjectId = commentModel.ProjectId;
        
        var updatedComment = await _commentRepository.UpdateAsync(_mapper.Map<Comment>(commentModel));
        
        return _mapper.Map<CommentModel>(updatedComment);
    }
    
    public async Task<CommentModel> DeleteAsync(Guid id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        
        if (comment == null)
        {
            throw new KeyNotFoundException($"Comment with id '{id}' was not found");
        }
        
        var deletedComment = await _commentRepository.DeleteAsync(comment);
        
        return _mapper.Map<CommentModel>(deletedComment);
    }
}