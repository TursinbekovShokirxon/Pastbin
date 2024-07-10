using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string HashUrl{ get; set; }
        public string UrlAWS{ get; set; }
        public User UserId{ get; set; }
    }
}
