using Pastbin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Domain.Models.DTO
{
    public class PostDTO
    {
        public string UserName { get; set; }
        public string Text { get; set; }
        public string HashUrl { get; set; }
    }
}
