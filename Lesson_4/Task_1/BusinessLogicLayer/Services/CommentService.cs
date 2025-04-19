using AutoMapper;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<CommentModel>> GetAllAsync()
    {
        var comments = await _commentRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<CommentModel>>(comments);
    }
    
    public async Task<CommentModel?> GetByIdAsync(Guid id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        
        if (comment == null)
        {
            return null;
        }
    
        return _mapper.Map<CommentModel>(comment);
    }
    
    public async Task<CommentModel> CreateAsync(CommentModel commentModel)
    {
        var createdComment = await _commentRepository.AddAsync(_mapper.Map<Comment>(commentModel));
        
        return _mapper.Map<CommentModel>(createdComment);
    }
    
    public async Task<CommentModel?> UpdateAsync(Guid id, CommentModel commentModel)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        
        if (comment == null)
        {
            return null;
        }
        
        comment.Text =  commentModel.Text;
        comment.UserId = commentModel.UserId;
        comment.ProjectId = commentModel.ProjectId;
        
        var updatedComment = await _commentRepository.UpdateAsync(_mapper.Map<Comment>(commentModel));
        
        return _mapper.Map<CommentModel>(updatedComment);
    }

    public async Task<CommentModel?> DeleteAsync(Guid id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        
        if (comment == null)
        {
            return null;
        }
        
        var deletedComment = await _commentRepository.DeleteAsync(comment);

        return _mapper.Map<CommentModel>(deletedComment);
    }
}