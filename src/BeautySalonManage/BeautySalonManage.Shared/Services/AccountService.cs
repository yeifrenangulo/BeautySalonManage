using BeautySalonManage.Application.DTOs.Users;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Sockets;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BeautySalonManage.Shared.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;

        public AccountService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(User usuario, string ipAddress)
        {
            JwtSecurityToken jwtSecurityToken = await GenerateJWTToken(usuario);
            AuthenticationResponse response = new()
            {
                Id = usuario.UserId,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName = usuario.UserName
            };

            var refreshToken = GenerateRefreshToken(ipAddress);
            response.RefreshToken = refreshToken.Token;

            return response;
        }

        private Task<JwtSecurityToken> GenerateJWTToken(User usuario)
        {
            string ipAddress = GetIpAddress();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim("userName", usuario.UserName),
                new Claim("uid", usuario.UserId.ToString()),
                new Claim("ip", ipAddress)
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["JWTSettings:Issuer"],
                audience: _configuration["JWTSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JWTSettings:DurationInMinutes"])),
                signingCredentials: signingCredentials
                );

            return Task.FromResult(jwtSecurityToken);
        }

        private static RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now,
                CreatedByIp = ipAddress
            };
        }

        private static string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RSACryptoServiceProvider();
            var randomBytes = new byte[40];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }

        private static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return string.Empty;
        }
    }
}
