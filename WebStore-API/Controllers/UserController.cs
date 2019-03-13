using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BL.DTOs;
using BL.Helpers;
using BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace WebStore_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        private readonly AppSettings appSettings;

        public UserController(UserService userService, IOptions<AppSettings> appSettings)
        {
            this.userService = userService;
            this.appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<JsonResult> Authenticate([FromBody]UserDTO user)
        {
            var authUser = await userService.Authentificate(user.Login, user.Password);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString("G"))
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new JsonResult(new { user = authUser, tokenString });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<UserDTO> Register([FromBody]UserDTO user)
        {
            return await userService.PostAsync(user);
        }

        [HttpGet("{id}")]
        public Task<UserDTO> GetById(int id)
        {
            return userService.GetOneAsync(id);
        }
    }
}
