using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserModel>> GetAllUsers();
    Task<UserModel> GetUserById(Guid id);
    Task<UserModel> AddUser(UserModel userModel);
    Task<UserModel> UpdateUser(Guid id, UserModel userModel);
    Task<UserModel> DeleteUser(Guid id);
}