using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CrudMVCByKING.Interfaces;
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Data;

namespace CrudMVCByKING.Repositories
{
    public class UserRepository : IUsers
    {
        private readonly UsersDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserRepository(UsersDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper= mapper;
            _configuration = configuration;
        }

        public async Task<List<UserDTO>> GetUserAllAsync()
        {
            var entity = await _context.Users.ToListAsync();
            var userDto = _mapper.Map<List<UserDTO>>(entity);
            return userDto;
        }

        public async Task<UserDTO> GetUserByIdAsync( Guid Id)
        {
            var user = await _context.Users.Include(c => c.Courses).FirstOrDefaultAsync(x => x.Id == Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var userDto =  _mapper.Map<UserDTO>(user);
            return userDto;
        }

        public async Task<UserDto> Register(UserDto userDTO)
        {
            var userExist = await _context.Users.FirstOrDefaultAsync(e => e.Name == userDTO.Name);
            var userEmailExists = await _context.Users.FirstOrDefaultAsync(e => e.Email == userDTO.Email);

            if (userExist is not null)
            { 
                throw new Exception("The User already exists");
            }
            if (userEmailExists != null)
            {
                throw new Exception("The Email already taken");
            }
            userDTO.Id = new Guid();
          
            var user = _mapper.Map<Users>(userDTO);
            user.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
            _context.Set<Users>().Add(user);    
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);

        }
        public string Login(LoginDto loginDto)
        {
            var user = _context.Users.FirstOrDefault(e => e.Email == loginDto.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                throw new Exception("Wrong password");
            }

            string jwtToken = GenerateToken(user);

            // Возвращаем только токен
            return jwtToken;
        }


        public async Task<UserDto?> UpdateUserAsync(UserDto userDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userDTO.Id) ?? throw new Exception("User not found");
            var userEmailExists = await _context.Users.FirstOrDefaultAsync(e => e.Email == userDTO.Email && e.Id != userDTO.Id);
            if (userEmailExists != null)
            {
                throw new Exception("The Email already taken");
            }

            var entity = _mapper.Map(userDTO, user);
            entity.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
            entity.Role = user.Role;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(user); 
        }

        public async Task DeleteUserAsync(Guid Id)
        {
            var deleteUser = await _context.Users.FindAsync(Id);
            _context.Users.Remove(deleteUser);
            await _context.SaveChangesAsync();
        }

    

        private string GenerateToken(Users user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                // Add other claims as needed (e.g., custom claims)
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task AddAdmin(Guid Id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id) ?? throw new Exception("User not found");
            user.Role = "Admin";
            await _context.SaveChangesAsync();
        }
    }
}
