using ECommerceBackEnd.Application.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Application.Abstractions.Storage
{
    public interface IStorage
    {
        Task<string> UploadAsync(IFormFile formFile, UploadDirectory uploadDirectory);
        Task<List<string>> UploadRangeAsync(List<IFormFile> formFiles, UploadDirectory uploadDirectory);
        string GetFileUrl(string? fileName, UploadDirectory uploadDirectory);
        Task DeleteAsync(string? fileName, UploadDirectory uploadDirectory);
    }
}
