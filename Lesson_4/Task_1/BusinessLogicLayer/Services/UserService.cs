using AutoMapper;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services;

public class UserService : IUserService
{ 
    private readonly IUserRepository _userRepository; 
    private readonly IMapper _mapper;
    
    public UserService(IUserRepository userRepository, IMapper mapper) 
    {
       _userRepository = userRepository;
       _mapper = mapper; 
    }
    
    public async Task<IEnumerable<UserModel>> GetAllUsers()
    {
        var users = await _userRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<UserModel>>(users);
    }
    
    public async Task<UserModel> GetUserById(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        
        if (user == null)
        {
            throw new KeyNotFoundException($"User with id '{id}' was not found");
        }
        
        return _mapper.Map<UserModel>(user);
    }
    
    public async Task<UserModel> AddUser(UserModel userModel)
    {
        var user = _mapper.Map<User>(userModel);
        
        var addedUser = await _userRepository.AddAsync(user);
        
        return _mapper.Map<UserModel>(addedUser);
    }
    
    public async Task<UserModel> UpdateUser(Guid id, UserModel userModel)
    {
        var user = await _userRepository.GetByIdAsync(id);
        
        if (user == null)
        {
            throw new KeyNotFoundException($"User with id '{id}' was not found");
        }
        
        user.Name = userModel.Name;
        user.SecondName = userModel.SecondName;
        
        var updatedUser = await _userRepository.UpdateAsync(user);
        
        return _mapper.Map<UserModel>(updatedUser);
    }
    
    public async Task<UserModel> DeleteUser(Guid id)
    { 
        var user = await _userRepository.GetByIdAsync(id);
        
        if (user == null)
        {
            throw new KeyNotFoundException($"User with id '{id}' was not found");
        }
        
        var deletedUser = await _userRepository.DeleteAsync(user);
        
        return _mapper.Map<UserModel>(deletedUser);
    }
}