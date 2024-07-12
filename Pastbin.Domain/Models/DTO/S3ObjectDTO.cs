using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Domain.Models.DTO
{
    public class S3ObjectDTO
    {
        public string? Name { get; set; }
        public string? PresignedURL { get; set; }
        public string? ExpireDays { get; set; }
    }
}
