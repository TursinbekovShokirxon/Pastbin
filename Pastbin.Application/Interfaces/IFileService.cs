using Microsoft.AspNetCore.Http;
using Pastbin.Domain.Entities;
using Pastbin.Domain.Models;
using Pastbin.Domain.Models.DTO;

namespace Pastbin.Application.Interfaces
{
    public interface IFileService
    {
        public Task<UploadFileResponse> UploadFileAsync(string bucketName, Stream fileStream, string fileName, int? expireHour, string? prefix);
        public Task<IEnumerable<S3ObjectDTO>> GetAllFilesAsync(string bucketName, string? prefix);
        public Task<Stream> GetFileByKeyAsync(string bucketName, string key);
        public Task<bool> DeleteFileAsync(string bucketName, string key);
    }
}
