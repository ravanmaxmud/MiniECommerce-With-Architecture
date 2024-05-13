using ECommerceBackEnd.Application.Contracts;
using ECommerceBackEnd.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ECommerceBackEnd.Infrastucture.Services
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;

        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
        }

        public async Task<List<string>> UploadAsync(IFormFile formFile, UploadDirectory uploadDirectory)
        {
            string directoryPath = GetUploadDirectory(uploadDirectory);

            if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

            var imageNameInFileSystem = GenerateUniqueFileName(formFile.FileName);
            var filePath = Path.Combine(directoryPath, imageNameInFileSystem);

            try
            {
                using FileStream fileStream = new FileStream(filePath, FileMode.Create);
                await formFile.CopyToAsync(fileStream);
                List<string> uploadedFiles = new List<string>();
                uploadedFiles.Add(imageNameInFileSystem);
                return uploadedFiles;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Some Things Went Wrong");
                throw;
            }
        }
        public async Task DeleteAsync(string? fileName, UploadDirectory uploadDirectory)
        {
            var deletePath = Path.Combine(GetUploadDirectory(uploadDirectory),fileName!);
            await Task.Run(() => File.Delete(deletePath));

        }

        public string GetFileUrl(string? fileName, UploadDirectory uploadDirectory)
        {
            string initialSegment = "custom-files/";
            switch (uploadDirectory)
            {
                case UploadDirectory.Products:
                    return $"{initialSegment}/Products/{fileName}";
                default:
                    throw new Exception("Somethings went wrong!!");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private string GetUploadDirectory(UploadDirectory uploadDirectory) 
        {
            string startPath = Path.Combine("wwwroot","custom-files");
            switch (uploadDirectory)
            {
                case UploadDirectory.Products:
                    return Path.Combine(startPath, "Products");
                default:
                    throw new Exception("Somethings went wrong!!");
            }
        }

        private string GenerateUniqueFileName(string fileName) 
        {
            return $"{Guid.NewGuid()}{Path.GetExtension(fileName)}";
        }
    }
}
