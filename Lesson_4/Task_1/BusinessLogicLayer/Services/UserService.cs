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
    
    public async Task<IEnumerable<UserModel>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<UserModel>>(users);
    }
    
    public async Task<UserModel?> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        
        if (user == null)
        {
            return null;
        }
      
        return _mapper.Map<UserModel>(user);
    }
    
    public async Task<UserModel> CreateAsync(UserModel userModel)
    {
        var createdUser = await _userRepository.AddAsync(_mapper.Map<User>(userModel));
        
        return _mapper.Map<UserModel>(createdUser);
    }
    
    public async Task<UserModel?> UpdateAsync(Guid id, UserModel userModel)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
        {
            return null;
        }

        user.Name = userModel.Name;
        user.SecondName = userModel.SecondName;

        var updatedUser = await _userRepository.UpdateAsync(user);

        return _mapper.Map<UserModel>(updatedUser);
    }

    public async Task<UserModel?> DeleteAsync(Guid id)
    { 
        var user = await _userRepository.GetByIdAsync(id);
        
        if (user == null)
        {
            return null;
        }
        
        var deletedUser = await _userRepository.DeleteAsync(user);
        
        return _mapper.Map<UserModel>(deletedUser);
    }
}