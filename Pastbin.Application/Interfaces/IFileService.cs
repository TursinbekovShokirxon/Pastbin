using Microsoft.AspNetCore.Http;
using Pastbin.Domain.Models;
using Pastbin.Domain.Models.DTO;

namespace Pastbin.Application.Interfaces
{
    public interface IFileService
    {
        public Task<UploadFileResponse> UploadFileAsync(string bucketName, IFormFile file, string? prefix, int? expireDay);
        public Task<IEnumerable<S3ObjectDTO>> GetAllFilesAsync(string bucketName, string? prefix);
        public Task<Stream> GetFileByKeyAsync(string bucketName, string key);
        public Task<bool> DeleteFileAsync(string bucketName, string key);
    }
}
