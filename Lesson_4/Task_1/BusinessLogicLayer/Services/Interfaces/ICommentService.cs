using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces;

public interface ICommentService
{
    Task<IEnumerable<CommentModel>> GetAllComments();
    Task<CommentModel> GetCommentById(Guid id);
    Task<CommentModel> AddComment(CommentModel commentModel);
    Task<CommentModel> UpdateComment(Guid id, CommentModel commentModel);
    Task<CommentModel> DeleteComment(Guid id);
}