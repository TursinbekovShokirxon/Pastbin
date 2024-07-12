using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pastbin.Domain.Entities
{
    public class Post
    {

        public int Id { get; set; }
        public string HashUrl{ get; set; }
        public string UrlAWS{ get; set; }

        public int ExpireHour { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        //public List<Comment> Comments{ get; set; }
    }
}
