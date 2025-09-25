using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Domain.Interfaces;
using MediatR;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Users.Commands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IRepository<TBL_User> _repository;

        public CreateUserHandler(IRepository<TBL_User> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new TBL_User
            {
                User_Name = request.UserName,
                Temporary_Deletion = false,
              //  password = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            await _repository.AddAsync(user);
            return user.Id_User;
        }
    }
}
