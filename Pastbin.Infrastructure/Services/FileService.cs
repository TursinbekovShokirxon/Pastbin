using Amazon.S3.Model;
using Amazon.S3;
using Microsoft.AspNetCore.Http;
using Pastbin.Domain.Models;
using Pastbin.Domain.Models.DTO;
using Pastbin.Application.Interfaces;

namespace Pastbin.Infrastructure.Services
{
    public class FileService: IFileService
    {
        private readonly IAmazonS3 _s3Client;
        public FileService(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<UploadFileResponse> UploadFileAsync(string bucketName,IFormFile file, string? prefix, int? expireDay)
        {
            var bucketExists = await _s3Client.DoesS3BucketExistAsync(bucketName);

            if (!bucketExists) return new UploadFileResponse
            { Success = false,
            Message = string.Empty,
            UploadedFilePath=null
            };
            
            var request = new PutObjectRequest()
            {
                BucketName = bucketName,
                Key = string.IsNullOrEmpty(prefix) ? file.FileName : $"{prefix?.TrimEnd('/')}/{file.FileName}",
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType
            };

            if (expireDay.HasValue)
            {
                request.Metadata.Add("x-amz-meta-ttl", expireDay.Value.ToString());
            }

            await _s3Client.PutObjectAsync(request);

            var urlRequest = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = request.Key,
                Expires = DateTime.UtcNow.AddMinutes(60) // Set URL expiration time
            };
            string url = _s3Client.GetPreSignedURL(urlRequest);

            return new UploadFileResponse()
            {
            Message=$"File {request.Key} is uploaded",
            Success = true,
            UploadedFilePath=url
            };
        }

        public async Task<IEnumerable<S3ObjectDTO>> GetAllFilesAsync(string bucketName, string? prefix)
        {
            var bucketExists = await _s3Client.DoesS3BucketExistAsync(bucketName);
            if (!bucketExists) return null;
            var request = new ListObjectsV2Request()
            {
                BucketName = bucketName,
                Prefix = prefix
            };
            var result = await _s3Client.ListObjectsV2Async(request);
            var s3Objects = result.S3Objects.Select(s =>
            {
                var metadataRequest = new GetObjectMetadataRequest
                {
                    BucketName = bucketName,
                    Key = s.Key
                };
                var metadataResponse = _s3Client.GetObjectMetadataAsync(metadataRequest).Result;

                var urlRequest = new GetPreSignedUrlRequest()
                {
                    BucketName = bucketName,
                    Key = s.Key,
                    Expires = DateTime.UtcNow.AddMinutes(1)
                };
                return new S3ObjectDTO()
                {
                    Name = s.Key.ToString(),
                    PresignedURL = _s3Client.GetPreSignedURL(urlRequest),
                    ExpireDays = metadataResponse.Metadata["x-amz-meta-ttl"]
                };
            });
            return s3Objects;
        }

        public async Task<Stream> GetFileByKeyAsync(string bucketName,string key)
        {
            var bucketExists = await _s3Client.DoesS3BucketExistAsync(bucketName);
            if (!bucketExists) return null;
            var S3Object = await _s3Client.GetObjectAsync(bucketName, key);

            Stream obj = S3Object.ResponseStream;

            return obj;
        }

        public async Task<bool> DeleteFileAsync(string bucketName, string key)
        {
            var bucketExists = await _s3Client.DoesS3BucketExistAsync(bucketName);
            if (bucketExists!) return false;

            var deletedObject = await _s3Client.DeleteObjectAsync(bucketName, key);

            if (deletedObject.HttpStatusCode == System.Net.HttpStatusCode.OK) return true;
            return false;
        }
    }
}
