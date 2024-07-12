using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pastbin.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username{ get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public List<Post> Posts{ get; set; }
    }
}
