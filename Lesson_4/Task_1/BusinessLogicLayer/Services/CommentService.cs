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
    
    public async Task<IEnumerable<CommentModel>> GetAllComments()
    {
        var comments = await _commentRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<CommentModel>>(comments);
    }
    
    public async Task<CommentModel> GetCommentById(Guid id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        
        if (comment == null)
        {
            throw new KeyNotFoundException($"Comment with id '{id}' was not found");
        }
        
        return _mapper.Map<CommentModel>(comment);
    }
    
    public async Task<CommentModel> AddComment(CommentModel commentModel)
    {
        if (await _userRepository.GetByIdAsync(commentModel.UserId) == null)
        {
            throw new InvalidOperationException($"User with id '{commentModel.UserId}' does not exist");
        }
        
        if (await _projectRepository.GetByIdAsync(commentModel.ProjectId) == null)
        {
            throw new InvalidOperationException($"Project with id '{commentModel.ProjectId}' does not exist");
        }
        
        var comment = _mapper.Map<Comment>(commentModel);
        
        var addedComment = await _commentRepository.AddAsync(comment);
        
        return _mapper.Map<CommentModel>(addedComment);
    }
    
    public async Task<CommentModel> UpdateComment(Guid id, CommentModel commentModel)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        
        if (comment == null)
        {
            throw new KeyNotFoundException($"Comment with id '{id}' was not found");
        }
        
        if (await _userRepository.GetByIdAsync(commentModel.UserId) == null)
        {
            throw new InvalidOperationException($"User with id '{comment.UserId}' does not exist");
        }
        
        if (await _projectRepository.GetByIdAsync(commentModel.ProjectId) == null)
        {
            throw new InvalidOperationException($"Project with id '{comment.ProjectId}' does not exist");
        }
        
        comment.Text =  commentModel.Text;
        comment.UserId = commentModel.UserId;
        comment.ProjectId = commentModel.ProjectId;
        
        var updatedComment = await _commentRepository.UpdateAsync(comment);
        
        return _mapper.Map<CommentModel>(updatedComment);
    }
    
    public async Task<CommentModel> DeleteComment(Guid id)
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