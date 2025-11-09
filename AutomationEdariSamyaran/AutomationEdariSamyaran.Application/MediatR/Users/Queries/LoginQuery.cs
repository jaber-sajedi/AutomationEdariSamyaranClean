using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Users.Queries
{
    

    public class LoginQuery : IRequest<(bool IsSuccess, string Token, string Message)>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
