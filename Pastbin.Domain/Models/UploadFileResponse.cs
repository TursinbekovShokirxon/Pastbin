using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Domain.Models
{
    public class UploadFileResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string UploadedFilePath { get; set; }
    }
}
