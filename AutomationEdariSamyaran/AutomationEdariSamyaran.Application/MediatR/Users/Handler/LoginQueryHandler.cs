using AutomationEdariSamyaran.Application.Common;
using AutomationEdariSamyaran.Application.MediatR.Users.Queries;
using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Users.Handler
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, (bool IsSuccess, string Token, string Message)>
    {
        private readonly AppDbContext _context;
        // برای تولید توکن می‌توانید از Jwt استفاده کنید
        // private readonly ITokenService _tokenService;

        public LoginQueryHandler(AppDbContext context/*, ITokenService tokenService*/)
        {
            _context =  context;
            // _tokenService = tokenService;
        }

        public async Task<(bool IsSuccess, string Token, string Message)> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            
            var username = DeviceInfo.Encrypt(request.UserName);
            var query = await _context.Users.AsNoTracking().AnyAsync(u => u.User_Name == username && u.TemporaryDeletion == false);
            
            if (query)
            {
                var user = (await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.User_Name == username));
                var paswwodrVirify = Hash_Class.VerifyMd5Hash(request.Password, user.password);
                if(paswwodrVirify == false)
                {
                    return (false, string.Empty, "اطلاعات نادرست است.");
                }

                var claims = new[]
                {
            new Claim(ClaimTypes.Name, request.UserName),
            new Claim(ClaimTypes.Role, "Admin")
        };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyUltraStrongSecretKeyWithEnoughLength123!"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "https://localhost:7265",
                    audience: "https://localhost",
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: creds
                );

                return (true, new JwtSecurityTokenHandler().WriteToken(token), "ورود موفق");
            }

            return (false, string.Empty, "اطلاعات نادرست است.");
        }

    }
}
