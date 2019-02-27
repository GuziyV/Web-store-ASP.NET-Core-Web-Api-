using AutoMapper;
using BL.DTOs;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class UserService : CRUDService<User, UserDTO>
    {
        public UserService(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<UserDTO> Authentificate(string nickname, string password)
        {
            if (string.IsNullOrEmpty(nickname) || string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Username or password can not be empty");

            var user = (await context.Set<User>().SingleOrDefaultAsync(u => u.Login == nickname));
            if(user == null || !VerifyPasswordHash(password, user.PasswordHash))
            {
                throw new ArgumentException("Wrong email or password");
            }
            context.SaveChangesAsync();
            return mapper.Map<User, UserDTO>(user);
        }

        public override async Task<UserDTO> PostAsync(UserDTO entity)
        {
            if (string.IsNullOrEmpty(entity.Password) || string.IsNullOrEmpty(entity.Login))
            {
                throw new ArgumentException("Login and password are required");
            }
            var user = mapper.Map<UserDTO, User>(entity);
            user.PasswordHash = CreatePasswordHash(entity.Password);
            context.Add(user);
            await context.SaveChangesAsync();
            return mapper.Map<User, UserDTO>(user);
        }


        // private helper methods
        private static byte[] CreatePasswordHash(string password)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                return  hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
