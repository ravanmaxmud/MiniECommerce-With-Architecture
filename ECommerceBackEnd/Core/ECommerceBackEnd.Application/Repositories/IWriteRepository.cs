﻿using ECommerceBackEnd.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Application.Repositories
{ 
    public interface IWriteRepository<T>  : IRepository<T>  where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Delete(T model);
        bool DeleteRange (List<T> datas);
        Task<bool> DeleteAsync(string id);
        bool UpdateAsync(T model);
        Task<int> SaveAsync();

        //Bunlarin Concreate leri ise Persistance katmanindaki Repositoryies folderinde yazilir

    }
}
