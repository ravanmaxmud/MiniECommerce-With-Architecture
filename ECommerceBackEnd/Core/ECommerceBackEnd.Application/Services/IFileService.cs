using ECommerceBackEnd.Application.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Application.Services
{
    public interface IFileService       
    {
        Task<UploadResult> UploadAsync(IFormFile formFile , UploadDirectory uploadDirectory);
        string GetFileUrl(string? fileName, UploadDirectory uploadDirectory);
        Task DeleteAsync(string? fileName , UploadDirectory uploadDirectory);

    }
}
