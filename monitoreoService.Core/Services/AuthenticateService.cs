
using monitoreo.Core.DTOs.Response;
using monitoreo.Core.Interfaces.Repositories;
using monitoreo.Core.Interfaces.Services;
using monitoreo.Core.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace monitoreo.Core.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordService _passwordService;
        private readonly TokenOptions _options;

        public AuthenticateService(IUnitOfWork unitOfWork, IPasswordService passwordService, IOptions<TokenOptions> options)
        {
            _unitOfWork = unitOfWork;
            _passwordService = passwordService;
            _options = options.Value;
        }

        public UserAuthResponseDTO ValidateUser(string? username, string? password)
        {
           
            UserAuthResponseDTO response = new UserAuthResponseDTO();
            string responseToken = string.Empty;
            if (username== "usuarioPrueba" && password=="123")
            {   
                responseToken = this.GetToken(username,password);
                response.Username = username;
                response.FullName = username;
                response.Token = responseToken;
            }
            return response;
        }

        private string GetToken(string? username, string? password)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _options.Subject),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                new Claim("username", username),
                new Claim("role", "user")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_options.TokenExpirationTime)),
                signingCredentials: singIn
                );
            
            string responseToken = new JwtSecurityTokenHandler().WriteToken(token);
            return responseToken;
        }
    }
}
