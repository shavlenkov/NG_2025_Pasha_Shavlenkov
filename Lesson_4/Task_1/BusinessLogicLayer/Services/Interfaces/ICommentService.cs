using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces;

public interface ICommentService
{
    Task<IEnumerable<CommentModel>> GetAllAsync();
    Task<CommentModel> GetByIdAsync(Guid id);
    Task<CommentModel> CreateAsync(CommentModel commentModel);
    Task<CommentModel> UpdateAsync(Guid id, CommentModel commentModel);
    Task<CommentModel> DeleteAsync(Guid id);
}