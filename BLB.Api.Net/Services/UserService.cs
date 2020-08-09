using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BLB.Api.Net.Interfaces;
using BLB.Api.Net.Models;
using BLB.Domain.Net.Interfaces;
using BLB.Domain.Net.Models;
using BLB.Shared.Net.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BLB.Api.Net.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings appSettings;
        private readonly IUserRepository userRepository;

        public UserService(IOptions<AppSettings> appSettings, IUserRepository userRepository)
        {
            this.appSettings = appSettings.Value;
            this.userRepository = userRepository;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = userRepository.AuthenticateUser(model.Username, model.Password);

            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetById(long id)
        {
            return userRepository.GetSingle(id);
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.JwtSharedSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(appSettings.AuthExpiryHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
