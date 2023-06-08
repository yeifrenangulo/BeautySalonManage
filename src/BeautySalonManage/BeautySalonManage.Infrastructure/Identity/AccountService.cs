using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Exceptions;
using BeautySalonManage.Application.Common.Models.Account;
using BeautySalonManage.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BeautySalonManage.Infrastructure.Identity;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtSettings _jwtSettings;

    public AccountService(UserManager<ApplicationUser> userManager, IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<AuthResponse> Login(AuthRequest request)
    {
        var user = await _userManager.FindByNameAsync(request.User)
            ?? throw new ApiException("El usuario y/o contraseña son invalidos");

        var hasher = new PasswordHasher<ApplicationUser>();
        var passwordVerificationResult = hasher.VerifyHashedPassword(null, user.PasswordHash, request.Password);

        if (passwordVerificationResult != PasswordVerificationResult.Success)
        {
            throw new ApiException($"El usuario y/o contraseña son invalidos");
        }

        JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);

        AuthResponse response = new()
        {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            UserName = user.UserName,
            FullName = $"{user.Name} {user.Surname}",
            RefreshToken = GenerateRefreshToken().Token
        };

        return response;
    }

    private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = new List<Claim>();

        for (int i = 0; i < roles.Count; i++)
        {
            roleClaims.Add(new Claim("roles", roles[i]));
        }

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
                new Claim("username", user.UserName)
            }
        .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials);

        return jwtSecurityToken;
    }

    private static RefreshToken GenerateRefreshToken()
    {
        return new RefreshToken
        {
            Token = RandomTokenString(),
            Expires = DateTime.UtcNow.AddDays(7),
            Created = DateTime.UtcNow
        };
    }

    private static string RandomTokenString()
    {
        using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
        var randomBytes = new byte[40];
        rngCryptoServiceProvider.GetBytes(randomBytes);
        
        return BitConverter.ToString(randomBytes).Replace("-", "");
    }
}
