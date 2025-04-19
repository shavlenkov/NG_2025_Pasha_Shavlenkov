using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserModel>> GetAllAsync();
    Task<UserModel?> GetByIdAsync(Guid id);
    Task<UserModel> CreateAsync(UserModel userModel);
    Task<UserModel?> UpdateAsync(Guid id, UserModel userModel);
    Task<UserModel?> DeleteAsync(Guid id);
}