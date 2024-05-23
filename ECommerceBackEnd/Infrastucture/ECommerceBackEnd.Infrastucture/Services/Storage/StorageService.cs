using ECommerceBackEnd.Application.Abstractions.Storage;
using ECommerceBackEnd.Application.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Infrastucture.Services.Storage
{
    public class StorageService : IStorageService
    {

        readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName { get => _storage.GetType().Name;}

        public async Task DeleteAsync(string? fileName, UploadDirectory uploadDirectory)
            => await _storage.DeleteAsync(fileName, uploadDirectory);

        public string GetFileUrl(string? fileName, UploadDirectory uploadDirectory)
           => _storage.GetFileUrl(fileName, uploadDirectory);

        public async Task<string> UploadAsync(IFormFile formFile, UploadDirectory uploadDirectory)
              => await _storage.UploadAsync(formFile, uploadDirectory);

        public Task<List<string>> UploadRangeAsync(List<IFormFile> formFiles, UploadDirectory uploadDirectory)
           => _storage.UploadRangeAsync(formFiles, uploadDirectory);
    }
}
