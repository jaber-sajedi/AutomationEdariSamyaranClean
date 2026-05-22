using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace AutomationEdariSamyaran.Application.DTOs
{
  public  class UserDto
    {
        public int Id { get; private set; }

        public string Username { get; private set; } = null!;
     
        public string PasswordHash { get; private set; } = null!;

        public int PersonalId { get; private set; }

        public bool IsDeleted { get; private set; } = false;

        public DateTime CreatedAt { get; private set; }
    }
}
