using ECommerceBackEnd.Application.Abstractions.Storage.Local;
using ECommerceBackEnd.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Infrastucture.Services.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        private readonly ILogger<LocalStorage> _logger;

        public LocalStorage(ILogger<LocalStorage> logger)
        {
            _logger = logger;
        }


        public async Task<List<string>> UploadRangeAsync(List<IFormFile> formFiles, UploadDirectory uploadDirectory)
        {
            string directoryPath = GetUploadDirectory(uploadDirectory);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var imageNamesInFileSystem = GenerateUniqueFileNames(formFiles.Select(p => p.FileName).ToList());
            var filePaths = imageNamesInFileSystem.Select(imageName => Path.Combine(directoryPath, imageName));

            try
            {
                foreach (var filePath in filePaths)
                {
                    using FileStream fileStream = new FileStream(filePath, FileMode.Create);

                    await Task.Run(() =>
                    {
                        formFiles.Select(f => f.CopyToAsync(fileStream));
                    });
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Some Things Went Wrong");
                throw;
            }
            return imageNamesInFileSystem;
        }

        public async Task<string> UploadAsync(IFormFile formFile, UploadDirectory uploadDirectory)
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
            }
            catch (Exception e)
            { 
                _logger.LogError(e, "Some Things Went Wrong");
                throw;
            }
            return imageNameInFileSystem;

        }
        public async Task DeleteAsync(string? fileName, UploadDirectory uploadDirectory)
        {
            var deletePath = Path.Combine(GetUploadDirectory(uploadDirectory), fileName!);
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
            string startPath = Path.Combine("wwwroot", "custom-files");
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

        private List<string> GenerateUniqueFileNames(List<string> fileNames)
        {
            List<string> result = new List<string>();
            foreach (string fileName in fileNames)
            {
                result.Add($"{Guid.NewGuid()}{Path.GetExtension(fileName)}");
            }
            return result;
        }
    }
}
