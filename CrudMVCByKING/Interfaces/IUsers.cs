using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;

namespace CrudMVCByKING.Interfaces
{
    public interface IUsers
    {
        Task<List<UserDTO>> GetUserAllAsync();
        Task<UserDTO> GetUserByIdAsync(Guid Id);
        Task<UserDto> Register(UserDto userDTO);
        string Login(LoginDto loginDto);
        Task<UserDto?> UpdateUserAsync(UserDto userDTO);
        Task DeleteUserAsync(Guid Id);
        Task AddAdmin(Guid Id);
    }
}
