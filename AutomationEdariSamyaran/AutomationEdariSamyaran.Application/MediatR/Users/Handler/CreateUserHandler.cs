using AutomationEdariSamyaran.Application.Common;
using AutomationEdariSamyaran.Application.MediatR.Users.Commands;
using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Users.Handler
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateUserHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                User_Name = request.UserName,
                TemporaryDeletion = false,
              password = Hash_Class.GetMd5Hash(request.Password),
              
            };

            await _context.Users.AddAsync(user);
           await  _context.SaveChangesAsync();
            return user.Id;
        }
    }
}
