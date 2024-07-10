using Pastbin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Domain.Models.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public List<int> Posts { get; set; }

    }
}
