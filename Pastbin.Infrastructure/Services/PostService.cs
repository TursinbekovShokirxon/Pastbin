using Pastbin.Application.Interfaces;
using Pastbin.Application.Services;
using Pastbin.Domain.Entities;
using Pastbin.Infrastructure.DataAccess;
using System.Text;
namespace Pastbin.Infrastructure.Services
{
    public class PostService : IPostService
    {
        public PastbinDbContext _db;

        public PostService(PastbinDbContext db)
        {
            _db = db;
        }

        private readonly IFileService _fileService;
        public PostService(IFileService fileService)
        {
            _fileService = fileService;
        }
        public async Task<Post> CreateAsync(Post entity, string text)
        {
            // Создание MemoryStream из текста
            byte[] byteArray = Encoding.UTF8.GetBytes(text);
            using (MemoryStream memoryStream = new MemoryStream(byteArray))
            {
                // Использование MemoryStream для загрузки файла
                var response = await _fileService.UploadFileAsync("shokir-demo-bucket", memoryStream, "file.txt", entity.ExpireHour, null);

                // Обновление сущности
                entity.UrlAWS = response.UploadedFilePath;
                entity.HashUrl = string.Join("", HashGenerator.sha256_hash(response.UploadedFilePath).Select(x => x).Take(40));
            }
            return entity;
        }
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdateAsync(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
