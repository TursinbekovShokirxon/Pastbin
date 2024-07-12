using Pastbin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Domain.Models.DTO
{
    public class UserCreateDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
